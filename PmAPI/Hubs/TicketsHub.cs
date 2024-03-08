using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PmAPI.Hubs
{
    public class TicketsHub : Hub
    {
        public async Task SendTicketUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveTicketUpdate", message);
        }

        public async Task SendLinkUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveLinkUpdate", message);
        }
    }
}