using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class SchoolClass
    {
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Class Name")]
        public string Id { get; set; }



        public DateTime Year { get; set; }

     
   
        public virtual ApplicationUser Teacher{ get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherId { get; set; }


        public virtual ICollection<ApplicationUser> Students { get; set; }

        public virtual List<StudentSchool> StudentsSchool { get; set; }

        public virtual List<TeacherSchool> TeacherSchool { get; set; }
    }
}
