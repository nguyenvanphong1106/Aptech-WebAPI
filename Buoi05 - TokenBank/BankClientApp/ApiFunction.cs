using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClientApp
{
    public class ApiFunction
    {
        static string url = "http://localhost:52476/api/";

        //LOGIN
        public static async Task<Account> Login(string accNo, string pin)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //dua vao accNo dong vao 1 acc sau do moi send di
                    Account acc = new Account()
                    {
                        AccountNo = accNo,
                        PIN = pin
                    };

                    //nho them application/json
                    StringContent data = new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8, "application/json");

                    using (var response = await client.PostAsync(url + "Login", data))
                    {
                        return JsonConvert.DeserializeObject<Account>(await response.Content.ReadAsStringAsync());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        //GET Balance
        public static async Task<decimal> GetBalance(int accId, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return decimal.Parse(await client.GetStringAsync(url + "Balance/" + accId + "?token" + token));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        //CHECK Balance
        public static async Task<Account> Check(string accNo, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    return JsonConvert.DeserializeObject<Account>(await client.GetStringAsync(url + "Check/" + accNo + "?token" + token));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
