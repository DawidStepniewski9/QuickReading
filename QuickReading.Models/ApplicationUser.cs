using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace QuickReading.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual Profile Profile { get; set; }
    }
}
