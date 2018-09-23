using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _136WinformShop
{
    class Function
    {
        static string url = "http://localhost:56249/api/";

        //LOAD CATEGORY
        public async static Task<Category> GetCategory(int id)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url + "Categories");
                    return JsonConvert.DeserializeObject<Category>(json);
                }
            }
            catch (Exception)
            {
                //error
            }
            return null;
        }

        //LOAD PRODUCT LIST
        public async static Task<List<Product>> GetProducts()
        {
            List<Product> list = new List<Product>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    list = JsonConvert.DeserializeObject<List<Product>>(json);  //add newtonsoftJSON then deserialze
                    return list;
                }
            }
            catch (Exception)
            {
                //error
            }
            return null;
        }

        //GET 1 PRODUCT
        public async static Task<Product> GetProduct(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url + "/" + id);
                    return JsonConvert.DeserializeObject<Product>(json);
                }
            }
            catch (Exception)
            {
                //error
            }
            return null;
        }

        //ADD NEW PRODUCT
        public async static Task<bool> PostProduct(Product s)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent data = new StringContent(
                        JsonConvert.SerializeObject(s),
                        Encoding.UTF8,
                        "application/json");

                    using (var response = await client.PostAsync(url, data))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //error
            }

            return false;
        }

        //PUT
        public async static Task<bool> PutProduct(Product s)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent data = new StringContent(
                        JsonConvert.SerializeObject(s),
                        Encoding.UTF8,
                        "application/json");

                    using (var response = await client.PutAsync(url + "/" + s.Id, data))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //error
            }
            return false;
        }

        //DELETE
        public async static Task<bool> DeleteProduct(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.DeleteAsync(url + "/" + id))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //error
            }
            return false;
        }
    }
}
