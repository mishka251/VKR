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
    public partial class ResultForm : Form
    {

        Dictionary<Illness, double> diagnose;
        List<int> symptomIDs;
        public ResultForm(Dictionary<Illness, double> diagnose, List<int> symptoms)
        {
            InitializeComponent();
            int row = 1;
            foreach (var d in diagnose)
            {
                dataGridView1.Rows.Add(row, d.Key.Name, d.Value);
                row++;
            }
            this.diagnose = diagnose;
            this.symptomIDs = symptoms;
        }

        void insertPatient(string name)
        {
            myDB.INSERT(

                "Patient",
                new List<(string, object)>() { ("Name", name) }
                );
        }

        bool hasPatient(string name)
        {
            var table = myDB.SELECT(
                 new List<string>() { "Id" },
                 new List<string>() { "Patient" },
                 new List<(string name, object val)>() { ("Name", name) }
                 );
            return table.Rows.Count > 0;
        }

        int getPatientId(string name)
        {
            var table = myDB.SELECT(
                new List<string>() { "Id" },
                new List<string>() { "Patient" },
                new List<(string name, object val)>() { ("Name", name) }
                );

            return int.Parse((string)table.Rows[0].ItemArray[0]);
        }


        void InsertDiagnose(int id, Dictionary<Illness, double> diagnose)
        {

            DataTable table = new DataTable();
            
            table.Columns.Add("PatientID");
            table.Columns.Add("IllnessID");
            Type t = Type.GetType("System.Single");
            table.Columns.Add("Ind").DataType = t;

            foreach (var par in diagnose)
            {
                table.Rows.Add(id, par.Key.id, (float)par.Value);
            }
            myDB.INSERT("IllnessForPatient", table);
        }

        void InsertSymptoms(int id, List<int> symptoms)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PatientID");
            table.Columns.Add("SymptomID");

            foreach (var sympt in symptoms)
            {
                table.Rows.Add(id, sympt);
            }
            myDB.INSERT("SymptomForPatient", table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!hasPatient(name))
                insertPatient(name);

            DateTime dt = DateTime.Now.Date;

            int id = getPatientId(name);
            
            InsertSymptoms(id, symptomIDs);
            InsertDiagnose(id, diagnose);
            MessageBox.Show("Ok");
        }
    }
}
