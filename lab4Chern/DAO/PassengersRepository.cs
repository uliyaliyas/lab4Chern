using lab4Chern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace lab4Chern.DAO
{
    public class PassengersRepository:IPassengersRepository
    {
        private readonly BlogDbContext db;
        public PassengersRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Passenger> GetAllPassengerWithTickets()
        {
            return db.Passengers.Include(d => d.Tickets);
        }
        public async Task<Passenger> AddPassenger(Passenger passenger)
        {
            db.Passengers.Add(passenger);
            await db.SaveChangesAsync();
            return passenger;
        }
        public async Task<Passenger> UpdatePassenger(Passenger model)
        {
            var passennger = await db.Passengers
                .Where(p => p.PassengerId == model.PassengerId)
                .FirstOrDefaultAsync();

            if (passennger != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    passennger.Name = model.Name;
                if (model.DateBirth != default(DateTime))
                {
                    passennger.DateBirth = model.DateBirth;
                }
                if (model.Passport >= 0)
                {
                    passennger.Passport = model.Passport;
                }
                if (!string.IsNullOrEmpty(model.PhoneNumber))
                    passennger.PhoneNumber = model.PhoneNumber;
                db.Passengers.Update(passennger);
                await db.SaveChangesAsync();
            }
            return passennger!;
        }
        public async Task<bool> DeletePassenger(int id)
        {
            var passenger = await db.Passengers.FirstOrDefaultAsync(p => p.PassengerId == id);

            if (passenger == null)
            {
                return false;
            }
            db.Passengers.Remove(passenger);
            await db.SaveChangesAsync();
            return true;
        }
        public Task<Passenger> GetPassengerById(int id)
        {
            var passenger = db.Passengers.Include(p => p.Tickets).
                FirstOrDefaultAsync(p => p.PassengerId == id);
            if (passenger != null) return passenger!;
            return null!;
        }

        public IQueryable<Passenger> GetPassengerOnly()
        {
            return db.Passengers.AsQueryable();
        }
    }
}
