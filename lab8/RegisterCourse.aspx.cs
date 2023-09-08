using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        private List<Student> students;  

        protected void Page_Load(object sender, EventArgs e)
        {
            students = (List<Student>)Session["students"];  

            if (!IsPostBack)
            {
                ddpStudent.Items.Add(new ListItem("Select.."));

                if (students != null && students.Count > 0)
                {
                    foreach (Student student in students)
                    {
                        ddpStudent.Items.Add(new ListItem(student.ToString(), student.Id.ToString()));
                    }
                }
            }
            if (!IsPostBack)
            {
                List<Course> courses = Helper.GetAvailableCourses();
                foreach (Course course in courses)
                {
                    ListItem listItem = new ListItem(course.Code + " - " + course.Title + " - " + course.WeeklyHours + " hours per week", course.Code); // Added course.Code as the value.
                    cblCourses.Items.Add(listItem);
                }

            }
        }
        protected void Save_Student(object sender, EventArgs e)
        {
            List<Course> selectedCourses = new List<Course>();

            // Fetching the selected student
            Student chosenStudent = null;
            string selectedValue = ddpStudent.SelectedValue;

            foreach (Student student in students)
            {
                if (student.Id.ToString() == selectedValue)
                {
                    chosenStudent = student;
                    break;
                }
            }

            // Building the list of selected courses
            foreach (ListItem item in cblCourses.Items)
            {
                if (item.Selected)
                {
                    Course selectedCourse = Helper.GetCourseByCode(item.Value);
                    selectedCourses.Add(selectedCourse);
                }
            }

            try
            {
                chosenStudent.RegisterCourses(selectedCourses);
                SummaryRegister.InnerHtml = $"Selected Student has registered {selectedCourses.Count} courses, {selectedCourses.Sum(c => c.WeeklyHours)} hours weekly.";
                SummaryRegister.Style["color"] = "pink";
            }
            catch (Exception ex)
            {
                SummaryRegister.InnerHtml = "Error: " + ex.Message;
                SummaryRegister.Style["color"] = "red";
            }
        }



    }
}