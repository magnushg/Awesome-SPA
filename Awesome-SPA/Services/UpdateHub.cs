using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SignalR.Hubs;

namespace Awesome_SPA.Services
{
    public class UpdateHub : Hub
    {
        private static Dictionary<string, ScheduleJob> _scheduledSearches = new Dictionary<string, ScheduleJob>();
        private object _lock = new object();

        public void ListenToSearch(string searchTerm)
        {
            StopExistingSchedule();
            var schedule = new ScheduleJob(() => ScheduledNotification(searchTerm, Caller));
            schedule.Start(TimeSpan.FromSeconds(20).TotalMilliseconds);
            lock (_lock)
            {
                _scheduledSearches.Add(Context.ConnectionId, schedule);
            }
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

        private void ScheduledNotification(string searchTerm, dynamic caller)
        {
            IInstagramService instagramService = new InstagramService();
            var serializedData = JsonConvert.SerializeObject(instagramService.GetImagesFromTag(searchTerm));
            caller.update(serializedData);
        }
    }
}