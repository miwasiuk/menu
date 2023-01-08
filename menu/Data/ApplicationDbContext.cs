using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using menu.Models;

namespace menu.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<menu.Models.Dish> Dish { get; set; }
        public DbSet<menu.Models.Role> Role { get; set; }
        public DbSet<menu.Models.UsersRoles> UsersRoles { get; set; }
    }
}