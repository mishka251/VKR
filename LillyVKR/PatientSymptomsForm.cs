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
    public partial class PatientSymptomsForm : Form
    {
        Dictionary<int, CheckBox> checlkBoxesForId;
        public PatientSymptomsForm(List<Category> categoryes)
        {
            InitializeComponent();
            checlkBoxesForId = new Dictionary<int, CheckBox>();

            foreach (Category cat in categoryes)
            {
                TabPage page = new TabPage(cat.Name);
                int height = 50;
                foreach (Symptom sym in cat.Symptoms)
                {
                    CheckBox cb = new CheckBox
                    {
                        Top = height,
                        Left = 50,
                        Text = sym.Name
                    };
                    height += 50;
                    page.Controls.Add(cb);
                    checlkBoxesForId.Add(sym.id, cb);
                }
                tabControl1.TabPages.Add(page);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, bool> symptoms = new Dictionary<int, bool>();
            List<int> usedSymptomIDs = new List<int>();
            foreach (var par in checlkBoxesForId)
            {
                symptoms.Add(par.Key, par.Value.Checked);
                if (par.Value.Checked)
                    usedSymptomIDs.Add(par.Key);
            }
            var res = Calculation.Probabilities(symptoms);
            ResultForm resForm = new ResultForm(res, usedSymptomIDs);
            resForm.Show();
        }
    }
}
