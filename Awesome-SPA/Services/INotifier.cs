using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;

namespace Awesome_SPA.Services
{
    public interface INotifier
    {
        void Notify(string message);
    }

    public class ImageFeedNotifier : INotifier
    {
        public void Notify(string message)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<UpdateEndpoint>();
            context.Connection.Broadcast(message);
        }
    }
}