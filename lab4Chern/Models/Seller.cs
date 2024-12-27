using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4Chern.Models
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SellerId { get; set; }
        [Required]
        public string? SellerName { get; set; }
        [Required]
        public ICollection<Ticket> ?Tickets { get; set; }
    }
}
