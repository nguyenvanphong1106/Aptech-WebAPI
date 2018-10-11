using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClientApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        async private void btnOK_Click(object sender, EventArgs e)
        {
            var acc = await ApiFunction.Login(txtAccNo.Text, txtPIN.Text);
            if(acc != null)
            {
                Program.account = acc;
                new frmMain().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fcked up!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
