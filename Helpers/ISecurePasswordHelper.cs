namespace HotelAngular.Helpers
{
    public interface ISecurePasswordHelper
    {
        string Hash(string password);
    }
}
