using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome_SPA.Services
{
    public interface IScheduler
    {
        void StartScedule();
    }

    public class InstagramFeedScheduler : IScheduler
    {
        private readonly INotifier _notifier;
        private readonly IInstagramService _instagramService;

        public InstagramFeedScheduler(INotifier notifier, IInstagramService instagramService)
        {
            _notifier = notifier;
            _instagramService = instagramService;
        }

        public void StartScedule()
        {
            
        }
    }
}