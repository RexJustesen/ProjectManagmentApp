using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PmAPI.DTO;
using PmAPI.Models;

namespace PmAPI.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(int projectId);
        Task<Ticket> CreateTicketAsync(int projectId, Ticket ticket);
        //Task<Ticket> DeleteTicketAsync(long id);
        //Task<TicketDto> UpdateTicketAsync(long id, TicketDto ticket);


    }
}