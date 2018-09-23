using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWFApp
{
    public class Functions  //contains all methods to process with api
    {
        static string url = "http://localhost:64166/api/students";
       

        //login method
        public async static Task<bool> Login(string username, string password)
        {
            try
            {
                string url_login = "http://localhost:64166/api/account";
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = Program.cookie;

                using (HttpClient client = new HttpClient(handler))
                {
                    StringContent data = new StringContent(
                        JsonConvert.SerializeObject(new LoginVM()
                        {
                            UserName = username,
                            Password = password
                        },
                     Encoding.UTF8,
                     "application/json");
                }
                using (var response = await client.PostAsync(url_login, data))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                //error
            }
            return false;
        }

        //load list
        public async static Task<List<Student>> GetStudents()
        {
            List<Student> list = new List<Student>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    list = JsonConvert.DeserializeObject<List<Student>>(json);  //add newtonsoftJSON then deserialze
                    return list;
                }
            }
            catch (Exception)
            {
                //error
            }

            //return list;
            return null;
        }

        //get 1 student
        public async static Task<Student> GetStudent(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url + "/" + id);
                    return JsonConvert.DeserializeObject<Student>(json);
                }
            }
            catch (Exception)
            {
                //error
            }

            //return list;
            return null;
        }

        //add new
        public async static Task<bool> PostStudent(Student s)
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
        public async static Task<bool> PutStudent(Student s)
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
        public async static Task<bool> DeleteStudent(int id)
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
