using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [StringLength(30)]
        public string? FirstName { get; set; }

        [StringLength(30)]
        public string? LastName { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        
        public ICollection<Service> Services { get; set; } = new HashSet<Service>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
