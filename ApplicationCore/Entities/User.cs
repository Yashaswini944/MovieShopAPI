using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool TwoFactorEnabled { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
