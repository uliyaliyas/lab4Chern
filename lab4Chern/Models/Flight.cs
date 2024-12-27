using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4Chern.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        [Required]
        public int FlightNumber { get; set; }
        [Required]
        public string DepartureAirport {  get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        [Required]
        public int PlaneType { get; set; }
        [Required]
        public int Seats { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        
    }
}
