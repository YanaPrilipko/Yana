namespace HotelAngular.ViewModels
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Model.User ToDbModel()
        {
            return new Model.User
            {
                Email = Email,
                Password = Password
            };

        }  
    }
}
