using QuickReading.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickReading.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        public float Score { get; set; }

        public DateTime DateOfAdd { get; set; }

        public TypeOfGame TypeOfGame { get; set; }

        public string Comment { get; set; }

        public string DescriptionProfile { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
