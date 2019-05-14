using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LillyVKR
{
    public partial class Formап1 : Form
    {
        public Formап1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientSymptomsForm patientForm = new PatientSymptomsForm(Calculation.categories);
            patientForm.Show();
        }
    }
}
