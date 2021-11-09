using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EventDelegateApp
{
    public partial class EventForm : Form
    {
        private const string requiredMessage = "Recuired";
        private readonly Studentservice _studentService;
        public EventForm()
        {
            _studentService = new Studentservice();
            InitializeComponent();
        }
        public void UpdateBtn_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(firstNameBox.Text) && string.IsNullOrEmpty(lastNameBox.Text))
            {
                result = "Please Select Value to Update";
                MessageBox.Show(result);
            }
            else
            {
                studentGridView.CurrentRow.Cells[1].Value = firstNameBox.Text;
                studentGridView.CurrentRow.Cells[2].Value = lastNameBox.Text;
            }
        }
        public void DeleteBtn_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(firstNameBox.Text) || string.IsNullOrEmpty(lastNameBox.Text))
            {
                result = "Please Select Value to Delete";
                MessageBox.Show(result);
            }
            else
            {
                studentGridView.CurrentRow.Cells[1].Value = string.Empty;
                studentGridView.CurrentRow.Cells[2].Value = string.Empty;
            }
        }

        public void SaveBtn_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(firstNameBox.Text) || string.IsNullOrEmpty(lastNameBox.Text))
            {
                result = "Please enter any firstName and lastName";
                MessageBox.Show(result);
            }
            else
            {
                _studentService.Add(new Student { Name = firstNameBox.Text, LastName = lastNameBox.Text });
                List<Student> students = _studentService.GetAll();
                UpdateDataSource(studentGridView, students);
            }
        }

        private void UpdateDataSource(DataGridView dataGrid, List<Student> students)
        {
            studentGridView.DataSource = null;
            studentGridView.Update();
            studentGridView.DataSource = students;
            studentGridView.Update();
        }
        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameBox.Text))
            {
                firstNameValidLbl.Text = requiredMessage;
                firstNameValidLbl.ForeColor = Color.Red;
            }
            else
            {
                firstNameValidLbl.Text = string.Empty;
            }
        }
        private void LastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameBox.Text))
            {
                lastNameValidLbl.Text = requiredMessage;
                lastNameValidLbl.ForeColor = Color.Red;
            }
            else
            {
                lastNameValidLbl.Text = string.Empty;
            }
        }
        private void StudentGridView_SelectionChanged(object sender, EventArgs e)
        {
            firstNameBox.Text = studentGridView.CurrentRow.Cells[1].Value.ToString();
            lastNameBox.Text = studentGridView.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
