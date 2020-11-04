using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTeste.Hubs
{
    public class LogHub : Hub
    {
        public async Task ReceberAcao(string usuario, string acao)
        {
            await Clients.All.SendAsync("AcaoRecebida", usuario, acao);
        }
    }
}
