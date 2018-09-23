using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Form2 : Form
    {
        //bien' co`
        int id = 0;
        Product p;

        string url = "http://localhost:58143/api/products";
        public Form2(int id)
        {
            InitializeComponent();
            this.id = id;

        }
        async private void Form2_Shown(object sender, EventArgs e)
        {
            if (id == 0)
            {
                p = new Product();
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    string data = await client.GetStringAsync(url + "/" + id);
                    p = JsonConvert.DeserializeObject<Product>(data);
                }
            }
            bindingSource1.DataSource = p;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        async private void btnOK_Click(object sender, EventArgs e)
        {
            if(id == 0)
            {
                try
                {
                    //POST (add new)
                    using (HttpClient client = new HttpClient())        
                    {
                        string json = JsonConvert.SerializeObject(p);   //unpack object p to json
                        
                        //ma hoa du lieu de day di
                        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                        //tao 1 string content
                        using (var response = await client.PostAsync(url, data))    //send data
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                //PUT (update,edit)
                try
                {
                    //POST (add new)
                    using (HttpClient client = new HttpClient())
                    {
                        string json = JsonConvert.SerializeObject(p);   //unpack object p to json

                        //ma hoa du lieu de day di
                        StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                        //tao 1 string content
                        using (var response = await client.PutAsync(url + "/" + id, data))      //put: url + id
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}
