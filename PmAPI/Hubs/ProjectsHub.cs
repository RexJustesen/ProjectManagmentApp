using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PmAPI.Data;

namespace PmAPI.Hubs
{
    public class ProjectsHub : Hub
    {


        public async Task SendProjectUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveProjectUpdate", message);
        }
    }
}