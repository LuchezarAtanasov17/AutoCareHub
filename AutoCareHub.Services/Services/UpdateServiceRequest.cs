﻿using AutoCareHub.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Web.Model.Services
{
    public class UpdateServiceRequest
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Location { get; set; } = null!;

        [Required]
        public TimeOnly OpenTime { get; set; }

        [Required]
        public TimeOnly CloseTime { get; set; }

        public List<MainCategory> MainCategories { get; set; }
    }
}