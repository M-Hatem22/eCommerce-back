using Microsoft.AspNetCore.SignalR;

namespace RestaurantApp.APIs.Hubs
{
    public class userHub:Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
