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

       // Dictionary<int, string> patirnNameForId;
      //  Dictionary<string, int> patientIdForName;
        int docId;

        public PatientsViewForm(int doc_id=-1)
        {
            this.docId = doc_id;
            InitializeComponent();
            loadSymptoms();
            loadIllness();
            loadPatints();

        }

        void loadIllness()
        {
            DataTable dt =
                 myDB.callTabFunc(
                "PatientIllnessForDoc",
                new List<(string, object)>() {
                    ("@docId", docId)
                }

                );
            //myDB.SELECT_ALL("PatientIllnessView");
            dgvIllness.DataSource = dt;
        }

        void loadSymptoms()
        {
            DataTable dt = myDB.callTabFunc(
                "PatientSymptomsForDoc",
                new List<(string, object)>() {
                    ("@docId", docId)
                }

                ); //myDB.SELECT_ALL("PatientSymptomsView");
            dgvSymptoms.DataSource = dt;
        }

        void loadPatints()
        {
           // patientIdForName = new Dictionary<string, int>();
           // patirnNameForId = new Dictionary<int, string>();

            comboBox1.Items.Clear();

            //    DataTable dt = myDB.SELECT_ALL("Patient");

            List<string> names = new List<string>();
            for (int i = 0; i < dgvIllness.Rows.Count; i++)
            {
                //int id = int.Parse((string)dt.Rows[i].ItemArray[0]);
                //      string name = (string)dt.Rows[i].ItemArray[1];

                // patientIdForName.Add(name, id);
                // patirnNameForId.Add(id, name);
                string name = (string)dgvIllness.Rows[i].Cells[0].Value;
                names.Add(name);
            }

            comboBox1.Items.AddRange(names.Distinct().ToArray());

        }


        void selectDGVRows()
        {
            var cm1 = dgvSymptoms.BindingContext[dgvSymptoms.DataSource] as CurrencyManager;
            var cm2 = dgvIllness.BindingContext[dgvIllness.DataSource] as CurrencyManager;
            cm1.SuspendBinding();
            cm2.SuspendBinding();

            for (int i = 0; i < dgvIllness.Rows.Count; i++)
            {

                    dgvIllness.Rows[i].Visible =
                        dgvIllness[0, i].Value.Equals(comboBox1.SelectedItem);
            }

            for (int i = 0; i < dgvSymptoms.Rows.Count; i++)
            {
               
                    dgvSymptoms.Rows[i].Visible =
                        dgvSymptoms[0, i].Value.Equals(comboBox1.SelectedItem);
            }

            cm1.ResumeBinding();
            cm2.ResumeBinding();
        }


        int dgvRowsCount()
        {
            int rows = 0;

            for (int i = 0; i < dgvIllness.Rows.Count; i++)
            {

                if (    dgvIllness[0, i].Value.Equals(comboBox1.SelectedItem))
                    rows++;
            }

            for (int i = 0; i < dgvSymptoms.Rows.Count; i++)
            {
                if (           dgvSymptoms[0, i].Value.Equals(comboBox1.SelectedItem))
                    rows++;
            }

            return rows;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvRowsCount() > 0)
            {
                selectDGVRows();
            }
            else
            {
                MessageBox.Show("Нет таких");
            }
           
        }
    }
}
