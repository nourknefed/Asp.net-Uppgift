﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School.Data
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [PersonalData]
        public string FirstName { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [PersonalData]
        public string LastName { get; set; }


        [PersonalData]
        public string DisplayName => $"{FirstName} {LastName}";

 
      
    }
}
