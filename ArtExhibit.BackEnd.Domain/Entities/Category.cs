using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtExhibit.BackEnd.Domain.Entities
{
    public sealed class Category
    {
        public int id { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string name { get; set; } = string.Empty;
    }
}
