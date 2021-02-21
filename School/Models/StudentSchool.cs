using School.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class StudentSchool
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string SchoolClassId { get; set; }

        public virtual ApplicationUser Student { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
    }
}
