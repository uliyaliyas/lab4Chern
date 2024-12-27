using lab4Chern.Models;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace lab4Chern.DAO
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetTicketsByFlight(int flightId); 
        IQueryable<Passenger> GetPassengersByFlight(int flightId);
        IQueryable<Ticket> GetTicketsByDateRange(DateTime startDate, DateTime endDate);
        IQueryable<Ticket> GetTicketsByPassenger(int passengerId); 
        IQueryable<Ticket> GetAllTickets();
        IQueryable<Passenger> GetAllPassengersWithTickets(); 
        IQueryable<Ticket> GetAllPassengersWithTickets(int passengerId);
    }
}
