using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        string url = "http://localhost:58143/api/products";

        public Form1()
        {
            InitializeComponent();
        }

        //new method
        async private void LoadProducts()
        {
            //new code
            using (HttpClient client = new HttpClient())
            {
                string data = await client.GetStringAsync(url);
                //MessageBox.Show(data);
                //dataGridView1.DataSource = JsonConvert.DeserializeObject<List<Product>>(data);
                var list = JsonConvert.DeserializeObject<List<Product>>(data);

                var rs = from p in list
                         select new
                         {
                             p.Id,
                             p.ProductName,
                             p.Price
                         };
                dgvProduct.DataSource = rs.ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvProduct.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            Form2 f = new Form2(id);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(0); //0 ==> add new
            if(f.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        async private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int id = int.Parse(dgvProduct.SelectedRows[0].Cells["Id"].Value.ToString());
                //PUT (update,edit,delete)
                try
                {
                    //POST (add new)
                    using (HttpClient client = new HttpClient())
                    {
                        //tao 1 string content
                        using (var response = await client.DeleteAsync(url + "/" + id))      //put: Delete
                        {
                            LoadProducts();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
