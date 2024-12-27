using lab4Chern.Models;
using Microsoft.EntityFrameworkCore;

namespace lab4Chern.DAO
{
    public class SellerRepository:ISellerRepository
    {
        private readonly BlogDbContext db;
        public SellerRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Seller> GetAllSellerWithTickets()
        {
            return db.Sellers.Include(d => d.Tickets);
        }
        public async Task<Seller> AddSeller(Seller seller)
        {
            db.Sellers.Add(seller);
            await db.SaveChangesAsync();
            return seller;
        }
        public async Task<Seller> UpdateSeller(Seller model)
        {
            var seller = await db.Sellers
                .Where(p => p.SellerId == model.SellerId)
                .FirstOrDefaultAsync();

            if (seller != null)
            {
                if (!string.IsNullOrEmpty(model.SellerName))
                    seller.SellerName = model.SellerName;              
                db.Sellers.Update(seller);
                await db.SaveChangesAsync();
            }
            return seller!;
        }
        public async Task<bool> DeleteSeller(int id)
        {
            var seller = await db.Sellers.FirstOrDefaultAsync(p => p.SellerId == id);

            if (seller == null)
            {
                return false;
            }
            db.Sellers.Remove(seller);
            await db.SaveChangesAsync();
            return true;
        }
        public Task<Seller> GetSellerById(int id)
        {
            var seller = db.Sellers.Include(p => p.Tickets).
                FirstOrDefaultAsync(p => p.SellerId == id);
            if (seller != null) return seller!;
            return null!;
        }

        public IQueryable<Seller> GetSellerOnly()
        {
            return db.Sellers.AsQueryable();
        }
    }
}
