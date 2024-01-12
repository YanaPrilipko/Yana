using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAngular.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataOfArrival { get; set; }
        public DateTime DataOfDeparture { get; set; }
        public House House { get; set; } 
        public int HouseId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
    }
}
