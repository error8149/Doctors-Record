using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Doctors_record.Form2;

namespace Doctors_record
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 registerPatientForm = new Form2();
            registerPatientForm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 patientListForm = new Form3();
            patientListForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
