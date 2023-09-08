﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class Course
    {
        public string Code { get; private set; }
        public string Title { get; private set; }
        public int WeeklyHours { get; set; }

        public Course(string code, string title)
        {
            this.Code = code;
            this.Title = title;
        }
    }
}