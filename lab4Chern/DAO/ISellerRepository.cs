using lab4Chern.Models;

namespace lab4Chern.DAO
{
    public interface ISellerRepository
    {
        IQueryable<Seller> GetAllSellerWithTickets();
        IQueryable<Seller> GetSellerOnly();
        Task<Seller> GetSellerById(int Id);
        Task<Seller> AddSeller(Seller seller);
        Task<bool> DeleteSeller(int id);
        Task<Seller> UpdateSeller(Seller model);
    }
}
