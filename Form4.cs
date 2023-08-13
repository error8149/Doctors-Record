using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Doctors_record.Form2;

namespace Doctors_record
{
    public partial class Form4 : Form
    {
        private readonly string name;
        private readonly string age;
        private readonly string connectionString = "Data Source=HP;Initial Catalog=Doctor;Integrated Security=True";

        public Form4(string name, string age)
        {
            InitializeComponent();
            this.name = name;
            this.age = age;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DisplayPatientDetails();
        }
        private void DisplayPatientDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Patients WHERE Name = @Name AND Age = @Age";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label8.Text = reader["Name"].ToString();
                            label9.Text = reader["Age"].ToString();
                            label10.Text = reader["Gender"].ToString();
                            label11.Text = ((DateTime)reader["Date"]).ToString("yyyy-MM-dd");
                            label12.Text = reader["Investigate"].ToString();
                        }
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
