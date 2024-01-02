using IDrobeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Domain.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndTime { get; set; }
        public string Address { get; set; }

        // Relation
        public ICollection<Order> Orders { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }

    public class AppRole : IdentityRole<string>
    {
    }
}
