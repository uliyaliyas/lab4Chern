using lab4Chern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lab4Chern.DAO
{
    public class FlightRepository: IFlightRepository
    {
        private readonly BlogDbContext db;
        public FlightRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Flight> GetAllFlightWithTickets()
        {
            return db.Flights.Include(d => d.Tickets);
        }
        public async Task<Flight> AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            await db.SaveChangesAsync();
            return flight;
        }
        public async Task<Flight> UpdateFlight(Flight model)
        {
            var flight = await db.Flights
                .Where(p => p.FlightId == model.FlightId)
                .FirstOrDefaultAsync();

            if (flight != null)
            {
                if (model.FlightNumber >= 0)
                {
                    flight.FlightNumber = model.FlightNumber;
                }
                if (!string.IsNullOrEmpty(model.DepartureAirport))
                    flight.DepartureAirport = model.DepartureAirport;
                if (!string.IsNullOrEmpty(model.ArrivalAirport))
                    flight.ArrivalAirport = model.ArrivalAirport;
                if (model.DepartureDate != default(DateTime))
                {
                    flight.DepartureDate = model.DepartureDate;
                }
                if (model.ArrivalDate != default(DateTime))
                {
                    flight.ArrivalDate = model.ArrivalDate;
                }
                if (model.PlaneType >= 0)
                {
                    flight.PlaneType = model.PlaneType;
                }
                if (model.Seats >= 0)
                {
                    flight.Seats = model.Seats;
                }
                db.Flights.Update(flight);
                await db.SaveChangesAsync();
            }
            return flight!;
        }
        public async Task<bool> DeleteFlight(int id)
        {
            var flight = await db.Flights.FirstOrDefaultAsync(p => p.FlightId == id);

            if (flight == null)
            {
                return false;
            }
            db.Flights.Remove(flight);
            await db.SaveChangesAsync();
            return true;
        }
        public Task<Flight> GetFlightById(int id)
        {
            var flight = db.Flights.Include(p => p.Tickets).
                FirstOrDefaultAsync(p => p.FlightId == id);
            if (flight != null) return flight!;
            return null!;
        }

        public IQueryable<Flight> GetAllFlights()
        {
            return db.Flights.AsQueryable();
        }

        
    }
}
