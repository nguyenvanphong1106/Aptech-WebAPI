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

namespace WinformAppAPI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        async private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //luu cookie ve container de xai lai. Cookie cua app la Program.cookie
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;

                using (HttpClient client = new HttpClient(handler))
                {
                    //truyen loginName theo chuoi json len
                    string json = "{\"LoginName\":\"" + txtLoginName.Text + "\",\"Password\":\"" + txtPassword.Text + "\"}";
                    //dinh nghia string content de gui di
                    StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                    //postasync truyen response chua cookie, cookie o day dc truyen sang form main
                    using (var response = await client.PostAsync("http://localhost:54718/api/Login", data))
                    {
                        //doc duoi dang chuoi, lay ve body content, deserial ra thanh --> object
                        Emp em = JsonConvert.DeserializeObject<Emp>(await response.Content.ReadAsStringAsync());

                        //chuyen sang form main
                        new frmMain(em).Show();
                        this.Hide();
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
