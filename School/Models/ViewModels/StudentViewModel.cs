using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        public string DisplayName => $"{FirstName} {LastName}";

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }



        public string SchoolClassId { get; set; }
    }
}
