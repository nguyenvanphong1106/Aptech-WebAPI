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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //lblAccName.Text = Program.account.AccountName;
            //lblBalance.Text = "$" + Program.account.Balance.ToString("N0");
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            new frmTransfer().ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        async private void timer1_Tick(object sender, EventArgs e)
        {
            //lblBalance.Text = "$" + (await ApiFunction.GetBalance(Program.account.Id, Program.account.Token)).ToString("N0");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblAccName.Text = Program.account.AccountName;
            lblBalance.Text = "$" + Program.account.Balance.ToString("N0");
        }
    }
}
