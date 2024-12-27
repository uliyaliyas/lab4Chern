using lab4Chern.DAO;
using lab4Chern.Models;

namespace lab4Chern.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Получить список всех авиарейсов")]
        public IQueryable<Flight> GetAllFlights([Service] IFlightRepository flightRepository) => flightRepository.GetAllFlights();

        [UseProjection]
        [UseFiltering]
        [GraphQLDescription("Получить список всех пассажиров для заданного авиарейса")]
        public IQueryable<Passenger> GetPassengersByFlight([Service] IPassengersRepository passengerRepository, int flightId) =>
            passengerRepository.GetPassengersByFlight(flightId);

        [GraphQLDescription("Получить список свободных мест для заданного авиарейса")]
        public async Task<List<int>> GetAvailableSeatsByFlight([Service] ITicketRepository ticketRepository, int flightId, [Service] IFlightRepository flightRepository)
        {
            var flight = await flightRepository.GetFlightById(flightId);
            if (flight == null) throw new Exception("Рейс не найден");

            var bookedSeats = ticketRepository.GetTicketsByFlight(flightId).Select(t => t.SeatNumber).ToList();
            var allSeats = Enumerable.Range(1, flight.Seats).ToList();

            return allSeats.Except(bookedSeats).ToList();
        }

        [UseProjection]
        [GraphQLDescription("Сформировать справку по пассажиру")]
        public IQueryable<Ticket> GetPassengerTravelHistory([Service] ITicketRepository ticketRepository, int passengerId) =>
            ticketRepository.GetAllPassengersWithTickets(passengerId);

        [GraphQLDescription("Рассчитать стоимость всех проданных билетов за заданный период времени")]
        public double CalculateSoldTicketsPrice([Service] ITicketRepository ticketRepository, DateTime startDate, DateTime endDate) =>
            ticketRepository.GetTicketsByDateRange(startDate, endDate).Sum(t => t.Price);

        [GraphQLDescription("Рассчитать стоимость всех проданных билетов на заданный авиарейс")]
        public double CalculateSoldTicketsPriceByFlight([Service] ITicketRepository ticketRepository, int flightId) =>
            ticketRepository.GetTicketsByFlight(flightId).Where(t => t.BuyDateTime != null).Sum(t => t.Price);

        [GraphQLDescription("Рассчитать стоимость всех непроданных билетов на заданный авиарейс")]
        public double CalculateUnsoldTicketsPriceByFlight([Service] ITicketRepository ticketRepository, int flightId) =>
            ticketRepository.GetTicketsByFlight(flightId).Where(t => t.BuyDateTime == null).Sum(t => t.Price);

        [UseProjection]
        [GraphQLDescription("Получить список детей для заданного авиарейса")]
        public IQueryable<Passenger> GetChildrenByFlight([Service] ITicketRepository ticketRepository, int flightId, [Service] IPassengersRepository passengerRepository) =>
            (IQueryable<Passenger>)ticketRepository.GetTicketsByFlight(flightId).Where(t => t.IsChild).Select(t => passengerRepository.GetPassengerById(t.PassengerId));

        [GraphQLDescription("Рассчитать стоимость приобретенных пассажиром билетов за заданный интервал времени")]
        public double CalculatePassengerTicketPriceByDateRange([Service] ITicketRepository ticketRepository, int passengerId, DateTime startDate, DateTime endDate) =>
            ticketRepository.GetTicketsByPassenger(passengerId).Where(t => t.BuyDateTime >= startDate && t.BuyDateTime <= endDate).Sum(t => t.Price);

        [GraphQLDescription("Рассчитать количество пассажиров для каждого авиарейса")]
        public IQueryable<object> CalculatePassengerCountByFlight([Service] ITicketRepository ticketRepository) =>
            ticketRepository.GetAllTickets().GroupBy(t => t.FlightId)
                .Select(g => new { FlightId = g.Key, PassengerCount = g.Count() });
    }
}
