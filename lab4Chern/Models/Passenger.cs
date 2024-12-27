using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4Chern.Models
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateBirth {  get; set; }
        [Required]
        public int Passport {  get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
