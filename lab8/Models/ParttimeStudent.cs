using lab8.Models;
using System.Collections.Generic;
using System;

public class ParttimeStudent : Student
{
    public static int MaxNumOfCourses { get; set; }

    public ParttimeStudent(string name) : base(name, "Part Time")
    {
    }

    public override void RegisterCourses(List<Course> selectedCourses)
    {
        if (selectedCourses.Count > MaxNumOfCourses)
        {
            throw new Exception($"Cannot register more than {MaxNumOfCourses} courses");
        }

        base.RegisterCourses(selectedCourses);

    }
    public override string ToString()
    {
        return $"{Id} – {Name} (Part time)";
    }
}
