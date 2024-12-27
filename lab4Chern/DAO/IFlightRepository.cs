using lab4Chern.Models;

namespace lab4Chern.DAO
{
    public interface IFlightRepository
    {
        IQueryable<Flight> GetAllFlightWithTickets();

        Task<Flight> GetFlightById(int Id);
        Task<Flight> AddFlight(Flight flight);
        Task<bool> DeleteFlight(int id);
        Task<Flight> UpdateFlight(Flight model);
        IQueryable<Flight> GetAllFlights();
    }
}
