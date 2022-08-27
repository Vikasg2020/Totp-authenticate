using Microsoft.EntityFrameworkCore;
using Totp_authenticate.DB_model;

namespace Totp_authenticate.DB
{
    public class Db_Conn: DbContext
    {


        public Db_Conn(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>Users { get; set; }

    }
}
