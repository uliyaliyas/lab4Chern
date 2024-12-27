using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4Chern.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int SellerID { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        public DateTime? BuyDateTime { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsChild { get; set; }
       
    }
}
