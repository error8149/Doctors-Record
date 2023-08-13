using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Doctors_record
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string age = textBox4.Text;
            string gender = comboBox1.SelectedItem.ToString();
            DateTime date = dateTimePicker1.Value;
            string investigate = richTextBox1.Text;

            string connectionString = "Data Source=HP;Initial Catalog=Doctor;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Patients (Name, Age, Gender, Date, Investigate) VALUES (@Name, @Age, @Gender, @Date, @Investigate)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Investigate", investigate);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Patient registered successfully!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFormFields();
            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClearFormFields();
            DialogResult = DialogResult.Cancel;
        }
        private void ClearFormFields()
        {
            textBox1.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            richTextBox1.Clear();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
