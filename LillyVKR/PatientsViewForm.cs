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
    public partial class PatientsViewForm : Form
    {

        Dictionary<int, string> patirnNameForId;
        Dictionary<string, int> patientIdForName;

        public PatientsViewForm()
        {
            InitializeComponent();
            loadPatints();
            loadSymptoms();
            loadIllness();
        }

        void loadIllness()
        {
            DataTable dt = myDB.SELECT_ALL("PatientIllnessView");
            dgvIllness.DataSource = dt;
        }

        void loadSymptoms()
        {
            DataTable dt = myDB.SELECT_ALL("PatientSymptomsView");
            dgvSymptoms.DataSource = dt;
        }

        void loadPatints()
        {
            patientIdForName = new Dictionary<string, int>();
            patirnNameForId = new Dictionary<int, string>();

            comboBox1.Items.Clear();

            DataTable dt = myDB.SELECT_ALL("Patient");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = int.Parse((string)dt.Rows[i].ItemArray[0]);
                string name = (string)dt.Rows[i].ItemArray[1];

                patientIdForName.Add(name, id);
                patirnNameForId.Add(id, name);

                comboBox1.Items.Add(name);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            var cm1 = dgvSymptoms.BindingContext[dgvSymptoms.DataSource] as CurrencyManager;
            var cm2 = dgvIllness.BindingContext[dgvIllness.DataSource] as CurrencyManager;
            cm1.SuspendBinding();
            cm2.SuspendBinding();

            for (int i = 0; i < dgvIllness.Rows.Count; i++)
            {

                if (!dgvIllness.Rows[i].Selected)
                    dgvIllness.Rows[i].Visible =
                        dgvIllness[0, i].Value.Equals(comboBox1.SelectedItem);
            }

            for (int i = 0; i < dgvSymptoms.Rows.Count; i++)
            {
                if (!dgvSymptoms.Rows[i].Selected)
                    dgvSymptoms.Rows[i].Visible =
                        dgvSymptoms[0, i].Value.Equals(comboBox1.SelectedItem);
            }

            cm1.ResumeBinding();
            cm2.ResumeBinding();
        }
    }
}
