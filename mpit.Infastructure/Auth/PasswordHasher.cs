using BCrypt.Net;
using mpit.Application.Intefaces.Auth;

namespace mpit.Infastructure.Auth
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hashedPasswors)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPasswors);
        }
    }
}
