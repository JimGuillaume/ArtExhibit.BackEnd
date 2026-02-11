using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtExhibit.BackEnd.Application.DTOs
{
    public class CreateUserTypeDTO
    {
        [Required(ErrorMessage = "User type name is required")]
        [MaxLength(50, ErrorMessage = "User type name cannot exceed 50 characters")]
        public string Name { get; set; } = null!;
    }
}
