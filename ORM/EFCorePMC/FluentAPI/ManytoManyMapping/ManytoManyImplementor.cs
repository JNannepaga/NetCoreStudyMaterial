using EFCorePMC.FluentAPI.ManytoManyMapping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCorePMC.FluentAPI.ManytoManyMapping
{
    public class ManytoManyImplementor
    {
        public static void Encounter()
        {
            Course c1 = new Course()
            {
                CourseName = "Java"
            };

            Course c2 = new Course()
            {
                CourseName = "C#"
            };

            Student s1 = new Student()
            {
                FirstName = "Fluffy",
                LastName = "Nans",
                Courses = new List<Course>() { c1, c2 }
            };

            Student s2 = new Student()
            {
                FirstName = "Goofy",
                LastName = "Nans",
                Courses = new List<Course>() { c1, c2 }
            };

            using (FAPIManytoManyDbContext dbContext = new FAPIManytoManyDbContext())
            {
                dbContext.Students.Add(s1);
                dbContext.Students.Add(s2);

                dbContext.SaveChanges();

                List<Student> students = dbContext.Students.Include(s => s.Courses).ToList();
                students.ForEach(s =>
                {
                    Console.WriteLine($"FullName = {s.FullName}");
                    
                    foreach (Course course in s.Courses)
                    {
                        Console.WriteLine($"CourseName : {course.CourseName}");
                    } 
                });
            }
        }
    }
}
