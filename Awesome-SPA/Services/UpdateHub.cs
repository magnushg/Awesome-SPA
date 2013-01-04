using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SignalR.Hubs;

namespace Awesome_SPA.Services
{
    public class UpdateHub : Hub, IDisconnect
    {
        private static Dictionary<string, ScheduleJob> _scheduledSearches = new Dictionary<string, ScheduleJob>();
        private static List<string> _recentSearches = new List<string>(); 
        private object _lock = new object();

        public Task ListenToSearch(string searchTerm)
        {
            StopExistingSchedule();
            var searchRepository = new SearchRepository();
            var schedule = new ScheduleJob(() => ScheduledNotification(searchTerm, Caller));
            schedule.Start(TimeSpan.FromSeconds(20).TotalMilliseconds);
            lock (_lock)
            {
                _scheduledSearches.Add(Context.ConnectionId, schedule);
                searchRepository.SaveSearch(new Search{Term = searchTerm, TimeStamp = DateTime.Now});
                //_recentSearches.Add(searchTerm);
            }
            return Clients.updateSearchTerms(searchRepository.GetAll().Select(s => s.Term).Distinct().Take(20));
        }

        private void ScheduledNotification(string searchTerm, dynamic caller)
        {
            IInstagramService instagramService = new InstagramService();
            var serializedData = JsonConvert.SerializeObject(instagramService.GetImagesFromTag(searchTerm));
            caller.update(serializedData);
        }

        private void StopExistingSchedule()
        {
           if(_scheduledSearches.ContainsKey(Context.ConnectionId))
           {
               lock(_lock)
               {
                   var oldSchedule = _scheduledSearches[Context.ConnectionId];
                   oldSchedule.Stop();
                   _scheduledSearches.Remove(Context.ConnectionId);
               }
           }
        }

        public Task Disconnect()
        {
            StopExistingSchedule();
            return Clients.leave(Context.ConnectionId, DateTime.Now.ToString());
        }
    }
}