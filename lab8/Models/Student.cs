using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class Student
    {
        private readonly int id;
        public int Id
        {
            get
            {
                return id;
            }
        }

        private readonly string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        private static readonly Random random = new Random();

        public Student(string name, string selectedValue)
        {
            this.name = name;
            id = random.Next(100000, 1000000);
            RegisteredCourses = new List<Course>();
        }

        public List<Course> RegisteredCourses { get; }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            
        }

        public int TotalWeeklyHours()
        {
            return RegisteredCourses.Sum(course => course.WeeklyHours);
        }

    }
}
