using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SignalR;

namespace Awesome_SPA.Services
{
    public interface INotifier
    {
        void Notify(string message);
        void SetupSearchSubscription(string searchTerm, object caller);
    }

    public class ImageFeedNotifier : INotifier
    {
        private IInstagramService _instagramService;

        public ImageFeedNotifier()
        {
            _instagramService = new InstagramService();
        }

        public void Notify(string message)
        {
           
        }

        public void SetupSearchSubscription(string searchTerm, dynamic caller)
        {
            var serializedData = JsonConvert.SerializeObject(_instagramService.GetImagesFromTag(searchTerm));
            var schedule = new ScheduleJob(() => Notify(serializedData));
            //schedule.Start();
        }
    }
}