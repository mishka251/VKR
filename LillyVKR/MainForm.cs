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

        int docId;
        public MainForm(int id)
        {
            this.docId = id;
            InitializeComponent();
        }

        //void insertDoctor(string name)
        //{
        //    myDB.INSERT(
        //        "Doctor",
        //        new List<(string, object)>() { ("Name", name) }
        //        );
        //}

        //bool hasDoctor(string name)
        //{
        //    var table = myDB.SELECT(
        //         new List<string>() { "Id" },
        //         new List<string>() { "Doctor" },
        //         new List<(string name, object val)>() { ("Name", name) }
        //         );
        //    return table.Rows.Count > 0;
        //}

        

        bool validName(string name)
        {
            if (name == "")
                return false;


            for (int i = 0; i < name.Length; i++)
            {
                bool validSymb = false;
                if ('a' <= name[i] && name[i] > 'z')
                    validSymb = true;

                if ('A' <= name[i] && name[i] > 'Z')
                    validSymb = true;

                if ('а' <= name[i] && name[i] > 'я')
                    validSymb = true;

                if ('А' <= name[i] && name[i] > 'Я')
                    validSymb = true;

                if (
                    name[i] == ' '
                    || name[i] == '.')
                    validSymb = true;
                if (!validSymb)
                    return false;

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string docName = tbName.Text;

            //if (!validName(docName))
            //{
            //    MessageBox.Show("Неверный ввод данных");
            //    return;
            //}

            //if (!hasDoctor(docName))
            //    insertDoctor(docName);

            //int docId = getDoctortId(docName);



            PatientSymptomsForm patientForm = new PatientSymptomsForm(Calculation.categories, docId);
            patientForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientsViewForm patientsView = new PatientsViewForm(docId);
            patientsView.Show();
        }
    }
}
