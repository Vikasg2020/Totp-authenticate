using Totp_authenticate.DB_model;

namespace Totp_authenticate.Users
{
    public interface Iuser
    {
        public User getUser(string userName);

    }
}
