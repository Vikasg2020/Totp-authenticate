using System.Linq;
using Totp_authenticate.DB;
using Totp_authenticate.DB_model;

namespace Totp_authenticate.Users
{
    public class UsersLogin: Iuser
    {

        private readonly Db_Conn _db;


        public UsersLogin(Db_Conn db)
        {
            _db=db; 
        }

        public User getUser(string mail) 
        { 


            var varifyUser= _db.Users.Where(x => x.Email == mail).FirstOrDefault();

            if(varifyUser==null)
            {
                return null;    
            }


            return varifyUser;  


         }

    }
}
