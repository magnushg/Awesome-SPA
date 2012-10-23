using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;

namespace Awesome_SPA.Services
{
    public interface IImageFeedNotifier
    {
        void Notify(string message);
    }

    public class ImageFeedNotifier : IImageFeedNotifier
    {
        public void Notify(string message)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<UpdateEndpoint>();
            context.Connection.Broadcast(message);
        }
    }
}