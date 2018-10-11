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
    public partial class frmTransfer : Form
    {
        Account acc_to;
        public frmTransfer()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        async private void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtReceiveAcc.Text.Equals(Program.account.AccountNo))
            {
                MessageBox.Show("Unable");
                return;
            }
            if(string.IsNullOrEmpty(txtReceiveAcc.Text) || txtReceiveAcc.Text.Length > 6)
            {
                MessageBox.Show("Wrong Format");
                return;
            }
            acc_to = await ApiFunction.Check(txtReceiveAcc.Text, Program.account.Token);
            if (acc_to != null)
            {
                lblAccNameTo.Text = acc_to.AccountName;
                panel1.Enabled = true;
            }
            else
            {
                 lblAccNameTo.Text = "Unknown";
                 panel1.Enabled = false;
            } 
        }
    }
}
