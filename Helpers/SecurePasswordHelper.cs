using System.Security.Cryptography;
using System.Text;

namespace HotelAngular.Helpers
{
    public class SecurePasswordHelper : ISecurePasswordHelper
    {
        public string Hash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
