using Microsoft.AspNetCore.Identity;

namespace menu.Models
{
    public class UsersRoles
    {
        public int Id { get; set; }
        public int? RolesId { get; set; }
        public virtual Role? Roles { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
