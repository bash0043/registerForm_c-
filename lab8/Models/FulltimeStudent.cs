using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name, "Full Time")
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Sum(course => course.WeeklyHours) > MaxWeeklyHours)
            {
                throw new Exception($"The total weekly hours of the selected courses cannot exceed {MaxWeeklyHours}");
            }

            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} – {Name} (Full time)";
        }
    }

}
