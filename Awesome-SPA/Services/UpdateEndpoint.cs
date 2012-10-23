using System.Threading.Tasks;
using SignalR;

namespace Awesome_SPA.Services
{
    public class UpdateEndpoint : PersistentConnection 
    {
        protected override Task OnConnectedAsync(IRequest request, string connectionId)
        {
            return Connection.Broadcast("Connection " + connectionId + " connected");
        }
    }
}