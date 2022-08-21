using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DAL.Entities
{
    public class Customer : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }

        public Order Order { get; set; }
    }
}