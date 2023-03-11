using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();

            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();

            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private void DisplayStudents(List<Student> students)
        {
            // clear the listview before filling it
            listViewStudents.Clear();

            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.Name);
                li.Tag = student;   // link student object to listview item
                listViewStudents.Items.Add(li);
            }
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentnumber_Click(object sender, EventArgs e)
        {
            //removing "click here" and adding collumns
            lblClickHere.Text = "";

            lblstudentnumber.Text = "Studentnumber";
            lblfrstname.Text = "Firstname";
            lbllstname.Text = "Lastname";

            //Getting the students info from the database
            StudentService newStudents = new StudentService();
            List<Student> students = newStudents.GetStudents();

            //writing the info in the somerenUI
            foreach (Student student in students)
            {
                //Splitting up student.Name into first and lastname
                string[] entireName = student.Name.Split(" ");

                //printing to the UI
                lblstudentId.Text += $"{student.Number}\n";
                lblfirst.Text += $"{entireName[0]}\n";
                lbllast.Text += $"{entireName[1]}\n";

            }
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}