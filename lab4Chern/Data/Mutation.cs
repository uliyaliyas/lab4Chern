using lab4Chern.DAO;
using lab4Chern.Models;
using Microsoft.Extensions.Hosting;

namespace lab4Chern.Data
{
    public class Mutation
    {
        public async Task<Passenger?> UpdatePassenger([Service] IPassengersRepository passengerRepository, Passenger model)
        {
            return await passengerRepository.UpdatePassenger(model);
        }
        public async Task<Flight?> UpdateFlight([Service] IFlightRepository flightRepository, Flight model)
        {
            return await flightRepository.UpdateFlight(model);
        }
        public async Task<Seller?> UpdateSeller([Service] ISellerRepository sellerRepository, Seller model)
        {
            return await sellerRepository.UpdateSeller(model);
        }

        public async Task<bool> DeletePassenger([Service] IPassengersRepository passengerRepository, int id)
        {
            return await passengerRepository.DeletePassenger(id);
        }
        public async Task<bool> DeleteFlight([Service] IFlightRepository flightRepository, int id)
        {
            return await flightRepository.DeleteFlight(id);
        }
        public async Task<bool> DeleteSeller([Service] ISellerRepository sellerRepository, int id)
        {
            return await sellerRepository.DeleteSeller(id);
        }
    }
}
