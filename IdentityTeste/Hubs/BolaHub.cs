using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Hubs
{
    public class BolaHub : Hub
    {
        public async Task SendX(int x)
        {
            await Clients.All.SendAsync("ReceberX", x);
        }

        public async Task SendY(int y)
        {
            await Clients.All.SendAsync("ReceberY", y);
        }
    }
}