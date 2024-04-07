using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [StringLength(30)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [StringLength(30)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the Appointments.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        /// <summary>
        /// Gets or sets the Services.
        /// </summary>
        public ICollection<Service> Services { get; set; } = new HashSet<Service>();

        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        /// <summary>
        /// Gets or sets the Likes.
        /// </summary>
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
