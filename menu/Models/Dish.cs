using Microsoft.AspNetCore.Identity;

namespace menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfServing { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}
