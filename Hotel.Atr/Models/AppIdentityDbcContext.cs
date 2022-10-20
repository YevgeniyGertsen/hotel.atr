using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Atr.Models
{
    public class AppIdentityDbcContext :
        IdentityDbContext<AppUser>
    {
        public AppIdentityDbcContext(DbContextOptions<AppIdentityDbcContext> options)
            : base(options)
        {

        }
    }
}
