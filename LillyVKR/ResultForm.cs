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
        public ResultForm(Dictionary<Illness, double> diagnose)
        {
            InitializeComponent();
            int row = 1;
            foreach (var d in diagnose)
            {
                dataGridView1.Rows.Add(row, d.Key.Name, d.Value);
                row++;
            }
        }
    }
}
