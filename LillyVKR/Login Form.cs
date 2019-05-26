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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

    
        bool checkLogin(string name, string pass)
        {

            var res = myDB.callScFunc(
                "CorrectLogin",

                new List<(string, object)>()
                {
                    ("@name", name),
                    ("@pass", pass)
                }
                );

           return res.Equals(true);

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
            string name = tbName.Text;
            string pass = tbPass.Text;

            if(!checkLogin(name, pass))
            {
                MessageBox.Show("Error, incorrect login/passwrd");
                return;
            }

            int id = getDoctortId(name);

            MainForm mf = new MainForm(id);
            mf.Show();

        }
    }
}
