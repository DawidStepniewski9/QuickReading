using QuickReading.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.MVC.Models
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

    }
}
