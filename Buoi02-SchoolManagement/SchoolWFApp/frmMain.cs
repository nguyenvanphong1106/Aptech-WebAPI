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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        async private void LoadStudent()
        {
            var list = await Functions.GetStudents();

            if (list != null)  //list co du lieu
            {
                var rs = from s in list
                         select new
                         {
                             s.Id,
                             s.StudentName,
                             s.Birthday
                         };
                dgvStudents.DataSource = rs.ToList();
            }
            else
            {
                //error
                MessageBox.Show("Load Data Error Occured");
            }
        }

        async private void frmMain_Shown(object sender, EventArgs e)                                //load
        {
            LoadStudent();
        }

        private void btnAdd_Click(object sender, EventArgs e)                                       //add
        {
            frmStudent f = new frmStudent(0);
            if(f.ShowDialog() == DialogResult.OK)
            {
                LoadStudent();
            }
        }

        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)        //edit
        {
            int id = int.Parse(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            frmStudent f = new frmStudent(id);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadStudent();
            }
        }

        async private void btnDelete_Click(object sender, EventArgs e)                              //delete
        {
            if (dgvStudents.SelectedRows.Count == 0) return;

            if(MessageBox.Show("Are you sure?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int id = int.Parse(dgvStudents.SelectedRows[0].Cells["Id"].Value.ToString());
                if (await Functions.DeleteStudent(id))
                {
                    LoadStudent();
                }
                else
                {
                    MessageBox.Show("Unable to delete!");
                }
            }
        }
    }
}
