using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LillyVKR
{
    public partial class PatientSymptomsForm : Form
    {
        Dictionary<int, CheckBox> checlkBoxesForId;

        Dictionary<int, RadioButton> RBsForId;

        int docId;
        public PatientSymptomsForm(List<Category> categoryes, int docId)
        {
            InitializeComponent();
            checlkBoxesForId = new Dictionary<int, CheckBox>();
            RBsForId = new Dictionary<int, RadioButton>();
            this.docId = docId;

            foreach (Category cat in categoryes)
            {
                TabPage page = new TabPage(cat.Name);
                page.AutoScroll = true;
                int height = 50;
                foreach (Symptom sym in cat.Symptoms)
                {
                    if(cat.OnlyOneCValue)
                    {
                        RadioButton rb = new RadioButton
                        {
                            Top = height,
                            Left = 50,
                            Text = sym.Name,
                            AutoSize = true
                        };
                        height += 50;
                        page.Controls.Add(rb);
                        RBsForId.Add(sym.id, rb);


                    }

                    else
                    {
                        CheckBox cb = new CheckBox
                        {
                            Top = height,
                            Left = 50,
                            Text = sym.Name,
                            AutoSize = true
                        };
                        height += 50;
                        page.Controls.Add(cb);
                        checlkBoxesForId.Add(sym.id, cb);

                    }

                }
                tabControl1.TabPages.Add(page);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, bool> symptoms = new Dictionary<int, bool>();
            List<int> usedSymptomIDs = new List<int>();
            bool hasOne = false;
            foreach (var par in checlkBoxesForId)
            {
                symptoms.Add(par.Key, par.Value.Checked);
                if (par.Value.Checked)
                {
                    usedSymptomIDs.Add(par.Key);
                    hasOne = true;
                }
            }

            foreach (var par in RBsForId)
            {
                symptoms.Add(par.Key, par.Value.Checked);
                if (par.Value.Checked)
                {
                    usedSymptomIDs.Add(par.Key);
                    hasOne = true;
                }
            }

            if(!hasOne)
            {
                MessageBox.Show("Ничего не заполнено, заполните");
                return;
            }

            var res = Calculation.Probabilities(symptoms);
            ResultForm resForm = new ResultForm(res, usedSymptomIDs, docId);
            resForm.Show();
        }
    }
}
