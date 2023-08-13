using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Doctors_record.Form2;

namespace Doctors_record
{
    public partial class Form3 : Form
    {
       

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            PopulatePatientList();
        }

        private void PopulatePatientList()
        {
            string connectionString = "Data Source=HP;Initial Catalog=Doctor;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Patients";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    DataGridView1.DataSource = dataTable;
                }
            }
        }

        
    


        private void Label3_Click(object sender, EventArgs e)
        {
           
        }
       
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                DataRowView selectedRow = DataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                string name = selectedRow["Name"].ToString();
                string age = selectedRow["Age"].ToString();

                using (Form4 patientDetailsForm = new Form4(name, age))
                {
                    patientDetailsForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to view.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
