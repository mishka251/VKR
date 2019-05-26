﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LillyVKR
{
    public partial class ResultForm : Form
    {

        Dictionary<Illness, double> diagnose;
        List<int> symptomIDs;
        int docId;
        public ResultForm(Dictionary<Illness, double> diagnose, List<int> symptoms, int docId)
        {
            InitializeComponent();
            this.docId = docId;

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

            table.Columns.Add("DoctorId");

            Type t1 = Type.GetType("System.DateTime");
            table.Columns.Add("Day").DataType = t1;

            foreach (var par in diagnose)
            {
                table.Rows.Add(id, par.Key.id, (float)par.Value, docId, DateTime.Now.Date);
            }
            myDB.INSERT("IllnessForPatient", table);
        }

        void InsertSymptoms(int id, List<int> symptoms)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PatientID");
            table.Columns.Add("SymptomID");
            table.Columns.Add("DoctorId");

            Type t1 = Type.GetType("System.DateTime");
            table.Columns.Add("Day").DataType = t1;

            foreach (var sympt in symptoms)
            {
                table.Rows.Add(id, sympt, docId, DateTime.Now.Date);
            }
            myDB.INSERT("SymptomForPatient", table);
        }


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
            string name = textBox1.Text;

            if (!validName(name))
            {
                MessageBox.Show("Заполните имя пациента");
                return;
            }

            if (!hasPatient(name))
                insertPatient(name);

            DateTime dt = DateTime.Now.Date;

            int id = getPatientId(name);

            InsertSymptoms(id, symptomIDs);
            InsertDiagnose(id, diagnose);
            MessageBox.Show("Пациент внесен в базу");
        }
    }
}
