using maEugeniAppV1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace maEugeniAppV1.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-wwform-urlencoded"));

        }

        public async Task<Token> Login(User user)
        {
           

            
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var weburl = "www.test.com";
            var response = await PostResponsLogin<Token>(weburl, content);
            DateTime dt = new DateTime();
            response.Expire_date = dt.AddSeconds(response.expires_in);
            return response;
        }

        public async Task<T> PostResponsLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_token);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Jsonresult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contetResp = JsonConvert.DeserializeObject<T>(Jsonresult);
                        return contetResp;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;
             
        }

        public async Task<T> GetResponse<T>(String weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_token);
            try
            {
                var result = await client.GetAsync(weburl);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Jsonresult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contetResp = JsonConvert.DeserializeObject<T>(Jsonresult);
                        return contetResp;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;

        }

    }
}
