using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name, "Co-op")
        {
        
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Sum(course => course.WeeklyHours) > MaxWeeklyHours)
            {
                throw new Exception($"The total weekly hours of the selected courses cannot exceed {MaxWeeklyHours}");
            }

            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Cannot register more than {MaxNumOfCourses} courses");
            }

            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} – {Name} (Co-op)";
        }
    }

}