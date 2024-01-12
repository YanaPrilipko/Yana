using HotelAngular.Model;

namespace HotelAngular.ViewModels.Order
{
    public class OrderCreateDto
    {

        public int Id { get; set; }
        public DateTime DataOfArrival { get; set; }
        public DateTime DataOfDeparture { get; set; }
        public int HouseId { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }

        public Model.Order ToDbModel()
        {
            return new Model.Order
            {
                Id = Id,
                CustomerId = CustomerId,
                DataOfArrival = DataOfArrival,
                DataOfDeparture = DataOfDeparture,
                HouseId = HouseId,
                Description = Description
            };
        }
    }
}
