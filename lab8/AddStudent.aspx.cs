using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();

        private List<string> types = new List<string>()
        {
            "Full Time",
            "Part Time",
            "Coop"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                ddpList.Items.Add(new ListItem("Select", ""));

                foreach (string type in types)
                {
                    ddpList.Items.Add(new ListItem(type));
                }
            }

            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
            }


            Display_Student();
        }

        protected void Add_Student(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Student student = null;
                string type = ddpList.SelectedValue;
                switch (type)
                {
                    case "Full Time":
                        student = new FulltimeStudent(txtName.Text);
                        break;
                    case "Part Time":
                        student = new ParttimeStudent(txtName.Text);
                        break;
                    case "Coop":
                        student = new CoopStudent(txtName.Text);
                        break;
                }

                if (student != null)
                {
                    students.Add(student);
                    Session["students"] = students;
                    Display_Student();
                    txtName.Text = string.Empty;
                    ddpList.SelectedIndex = 0;
                }
            }
        }


        protected void Display_Student()
        {
            tblDetails.Rows.Clear(); 




            // Create the table header row.
            TableHeaderRow tableHeaderRow = new TableHeaderRow();

            TableHeaderCell idHeaderCell = new TableHeaderCell();
            idHeaderCell.Text = "ID";
            tableHeaderRow.Cells.Add(idHeaderCell);

            TableHeaderCell nameHeaderCell = new TableHeaderCell();
            nameHeaderCell.Text = "Name";
            tableHeaderRow.Cells.Add(nameHeaderCell);

            tblDetails.Rows.Add(tableHeaderRow);
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(ddpList.SelectedValue) && students.Count == 0)
            {
                // Create a single row with the "No student yet" message.
                TableRow noStudentRow = new TableRow();
                TableCell noStudentCell = new TableCell();
                noStudentCell.Text = "No student yet";
                noStudentCell.CssClass = "fw-bold text-danger-emphasis text-center";
                noStudentCell.ColumnSpan = 2;
                noStudentRow.Cells.Add(noStudentCell);
                tblDetails.Rows.Add(noStudentRow);
            }
            else
            {
                // Create rows for each student.
                foreach (Student student in students)
                {
                    TableRow row = new TableRow();

                    TableCell id = new TableCell();
                    id.Text = student.Id.ToString();
                    row.Cells.Add(id);

                    TableCell name = new TableCell();
                    name.Text = student.Name;
                    row.Cells.Add(name);

                    tblDetails.Rows.Add(row);


                }

            }


        }
    }
}