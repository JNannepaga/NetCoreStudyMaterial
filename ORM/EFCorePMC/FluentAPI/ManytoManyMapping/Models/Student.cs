using System.Collections.Generic;

namespace EFCorePMC.FluentAPI.ManytoManyMapping.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + this.LastName; } }

        //Navigation Properties
        //public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Student()
        {
            //this.StudentCourses = new HashSet<StudentCourses>();
            this.Courses = new HashSet<Course>();
        }
    }
}
