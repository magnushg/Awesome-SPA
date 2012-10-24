using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace Awesome_SPA.Services
{
    public class UpdateHub : Hub
    {
        public void Send(string message)
        {
            Clients.add(message);
        }
    }
}