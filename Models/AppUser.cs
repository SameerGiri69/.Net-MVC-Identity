using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace IdentityPractice.Models
{
    public class AppUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        

    }
}
