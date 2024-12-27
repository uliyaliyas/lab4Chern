using lab4Chern.Models;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace lab4Chern.DAO
{
    public interface IPassengersRepository
    {
        IQueryable<Passenger> GetAllPassengerWithTickets();
        IQueryable<Passenger> GetPassengerOnly();
        Task<Passenger> GetPassengerById(int Id);
        Task<Passenger> AddPassenger(Passenger passenger);
        Task<bool> DeletePassenger(int id);
        Task<Passenger> UpdatePassenger(Passenger model);
        IQueryable<Passenger> GetPassengersByFlight(int flightId);
    }
}
