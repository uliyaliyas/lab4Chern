using lab4Chern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace lab4Chern.DAO
{
    public class TicketRepository: ITicketRepository
    {
        private readonly BlogDbContext db;
        public TicketRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Ticket> GetAllTicket()
        {
            return db.Tickets.AsQueryable();
        }
        public IQueryable<Ticket> GetTicketsByFlight(int flightId)
        {
            return db.Tickets.Where(t => t.FlightId == flightId);
        }
        public IQueryable<Passenger> GetPassengersByFlight(int flightId)
        {
            return db.Tickets
                .Where(t => t.FlightId == flightId)
                .Select(t => t.PassengerId)
                .Distinct()
                .Join(db.Passengers, ticketPassengerId => ticketPassengerId, passenger => passenger.PassengerId, (ticketPassengerId, passenger) => passenger);
        }
        public IQueryable<Ticket> GetTicketsByDateRange(DateTime startDate, DateTime endDate)
        {
            return db.Tickets.Where(t => t.BuyDateTime != null && t.BuyDateTime >= startDate && t.BuyDateTime <= endDate);
        }
        public IQueryable<Ticket> GetTicketsByPassenger(int passengerId)
        {
            return db.Tickets.Where(t => t.PassengerId == passengerId);
        }
        public IQueryable<Ticket> GetAllTickets()
        {
            return db.Tickets;
        }
        public IQueryable<Passenger> GetAllPassengersWithTickets()
        {
            return db.Tickets
                .Select(t => t.PassengerId)
                .Distinct()
                .Join(db.Passengers, ticketPassengerId => ticketPassengerId, passenger => passenger.PassengerId, (ticketPassengerId, passenger) => passenger);
        }

        public IQueryable<Ticket> GetAllPassengersWithTickets(int passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
