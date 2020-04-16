using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeProjectMVC.Models
{
    [Table("tblStudent")]
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int StudentRollNumber { get; set; }

        public string StudentCourse { get; set; }

        public int StudentSemester { get; set; }

        public string StudentUniversity { get; set; }
    }
}