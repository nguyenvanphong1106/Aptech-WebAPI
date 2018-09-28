using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformAppAPI
{
    public partial class frmMain : Form
    {
        private Emp em;

        public frmMain()
        {
            InitializeComponent();
        }

        //gen constructor for frmlogin.cs
        public frmMain(Emp em)
        {
            this.em = em;
            this.Text += " - [" + em.EmployeeName + "]";    //show ten user dang dang nhap hien tai
        }

        async private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                //copy from Browser/Network/Product
                //string agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                //string cookie = "__RequestVerificationToken=N09mMvLkv61hFYwCyhdOIM8O0e_U8DkyufNxMX3t-aLn0hHpxiPXIQAUgp-k5WWTdJZoD-_ZX6wQ8qRYQ5eRTRmXFPAAr3HsIks4KYc9v0c1; .ASPXAUTH=4A9C29EC987A14D600B42B0D45F6DACADAD7767FEC014BBCCAA791A43A7BC26BC3F8650DFD9C813CC7ACDB212A5B65BB3144451DDF481B42E453205063B321B889F3C357056725EF2F377A2C30EBB35F";

                //dua cookie vao trong thung container nay
                //HttpClientHandler handler = new HttpClientHandler();
                //CookieContainer container = new CookieContainer();
                //container.Add(new Cookie("ASPXAUTH"));

                //luu cookie ve container de xai lai. Cookie cua app la Program.cookie
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;   //dung lai cookie tu Login

                using (HttpClient client = new HttpClient(handler))
                {
                    //dinh kem` header, gui dung cookie
                    //client.Headers.Add("User-Agent", agent);
                    //client.Headers.Add("Cookie", cookie);

                    //send get
                    string json = await client.GetStringAsync("http://localhost:54718/api/products");
                    dgvProduct.DataSource = JsonConvert.DeserializeObject<List<Product>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
