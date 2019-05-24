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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void insertDoctor(string name)
        {
            myDB.INSERT(
                "Doctor",
                new List<(string, object)>() { ("Name", name) }
                );
        }

        bool hasDoctor(string name)
        {
            var table = myDB.SELECT(
                 new List<string>() { "Id" },
                 new List<string>() { "Doctor" },
                 new List<(string name, object val)>() { ("Name", name) }
                 );
            return table.Rows.Count > 0;
        }

        int getDoctortId(string name)
        {
            var table = myDB.SELECT(
                new List<string>() { "Id" },
                new List<string>() { "Doctor" },
                new List<(string name, object val)>() { ("Name", name) }
                );

            return int.Parse((string)table.Rows[0].ItemArray[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string docName = tbName.Text;

            if (!hasDoctor(docName))
                insertDoctor(docName);

            int docId = getDoctortId(docName);
                


            PatientSymptomsForm patientForm = new PatientSymptomsForm(Calculation.categories, docId);
            patientForm.Show();
        }
    }
}
