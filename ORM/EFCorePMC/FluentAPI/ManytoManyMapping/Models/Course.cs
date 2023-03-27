using System.Collections.Generic;

namespace EFCorePMC.FluentAPI.ManytoManyMapping.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Code { get; set; }

        //Navigational Properties
        //public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            //this.StudentCourses = new HashSet<StudentCourses>();
            this.Students = new HashSet<Student>();
        }
    }
}
