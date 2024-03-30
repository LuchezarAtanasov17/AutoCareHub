﻿using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public User User { get; set; }

        public Service Service { get; set; }

        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
