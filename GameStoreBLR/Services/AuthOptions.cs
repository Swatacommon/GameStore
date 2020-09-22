using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GameStoreBLR.Services {
    public class AuthOptions {
        public const string ISSUER = "GameStoreServer"; // издатель токена
        public const string AUDIENCE = "GameStoreClient"; // потребитель токена
        const string KEY = "myswatarcommonkey1337";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey() {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
