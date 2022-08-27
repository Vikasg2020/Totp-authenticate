namespace Totp_authenticate.DB_model
{
    public class User
    {

        public int Id { get; set; } 
        public string UserName { get; set; }

       // public string otp { get; set; }

        public string Email { get; set; }

        public string pass { get; set; }

        public string UserRole { get; set; }

    }
}
