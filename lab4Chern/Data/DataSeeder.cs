using Bogus.DataSets;
using lab4Chern.Models;
using Microsoft.Extensions.Hosting;
using Faker;

namespace lab4Chern.Data
{
    public static class DataSeeder
    {
        public static void SeedData(BlogDbContext db)
        {
            Random random = new Random();

            if (!db.Passengers.Any())
            {
                for (int i = 1; i <= 12; i++)
                {
                    var passenger = new Passenger
                    {
                        Name = Faker.Name.FullName(),
                        Passport=random.Next(0,10),
                        PhoneNumber=$"+7{random.Next(0,10)}",
                        Email=Faker.Internet.FreeEmail(),
                        DateBirth=new DateTime(random.Next(1950,2010),random.Next(1,13),random.Next(1,28)),
                    };
                    db.Passengers.Add(passenger);
                    for (int j = 0; j < 10; j++)
                    {
                        var ticket = new Ticket
                        {
                            SeatNumber = random.Next(0, 200),
                            BuyDateTime = new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 28)),
                            Price = random.Next(500, 100000),
                            IsChild = false
                        };
                        db.Tickets.Add(ticket);
                    }
                }
            }
            if (!db.Flights.Any())
            {
                for (int i = 1; i <= 12; i++)
                {
                    var flight = new Flight
                    {
                        FlightNumber = random.Next(0, 10000),
                        DepartureAirport=Faker.Internet.DomainWord(),
                        ArrivalAirport = Faker.Internet.DomainWord(),
                        DepartureDate = new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 28)),
                        Seats=random.Next(10,200),
                        PlaneType=random.Next(0,2000)
                    };
                    db.Flights.Add(flight);
                    //for (int j = 0; j < 10; j++)
                    //{
                    //    var ticket = new Ticket
                    //    {
                    //        SeatNumber = random.Next(0, 200),
                    //        BuyDateTime = new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 28)),
                    //        Price = random.Next(500, 100000),
                    //        IsChild = false
                    //    };
                    //    db.Tickets.Add(ticket);
                    //}
                }
            }
            if (!db.Sellers.Any())
            {
                for (int i = 1; i <= 12; i++)
                {
                    var seller = new Seller
                    {
                        SellerName=Faker.Name.FullName()
                    };
                    db.Sellers.Add(seller);
                    //for (int j = 0; j < 10; j++)
                    //{
                    //    var ticket = new Ticket
                    //    {
                    //        SeatNumber = random.Next(0, 200),
                    //        BuyDateTime = new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 28)),
                    //        Price = random.Next(500, 100000),
                    //        IsChild = false
                    //    };
                    //    db.Tickets.Add(ticket);
                    //}
                }
            }
            db.SaveChanges();
        }
    }
}
