using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolWFApp
{
    public partial class frmStudent : Form
    {
        int id = 0;
        Student s;

        public frmStudent(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        async private void frmStudent_Shown(object sender, EventArgs e)
        {
            if(id == 0)  //new
            {
                s = new Student()
                {
                    Birthday = DateTime.Now
                };
            }
            else //edit
            {
                s = await Functions.GetStudent(id);
                if(s == null)
                {
                    MessageBox.Show("An error occured");
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            bindingSource1.DataSource = s;
        }

        async private void btnSave_Click(object sender, EventArgs e)
        {
            if(id == 0)
            {
                if(await Functions.PostStudent(s))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Post Error!");
                }
            }
            else
            {
                if(await Functions.PutStudent(s))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Put Error!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
