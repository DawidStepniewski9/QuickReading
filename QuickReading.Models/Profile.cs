using System;
using System.ComponentModel.DataAnnotations;

namespace QuickReading.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string ImageProfileUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string City { get; set; }

        public string DescriptionProfile { get; set; }

    }
}
