using Alisan.RaporRestApi.Models.Login;
using Alisan.RaporRestApi.Models.PowerBI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Alisan.RaporRestApi.Core
{
    public static class PowerBITokenCreate
    {
        public static TokenResponse TokenCreate()
        {
            var token_base_url = ConfigData.GetConfiguration<string>("PowerBITokenSettings:token_base_url");
            var token_path = ConfigData.GetConfiguration<string>("PowerBITokenSettings:token_path");
            var client_id = ConfigData.GetConfiguration<string>("PowerBITokenSettings:client_id");
            var grant_type = ConfigData.GetConfiguration<string>("PowerBITokenSettings:grant_type");
            var resource = ConfigData.GetConfiguration<string>("PowerBITokenSettings:resource");
            var username = ConfigData.GetConfiguration<string>("PowerBITokenSettings:username");
            var password = ConfigData.GetConfiguration<string>("PowerBITokenSettings:password");
            var scope = ConfigData.GetConfiguration<string>("PowerBITokenSettings:scope");
            var client_secret = ConfigData.GetConfiguration<string>("PowerBITokenSettings:client_secret");

            using (HttpClient client= new HttpClient())
            {
                client.BaseAddress = new Uri(token_base_url);
                var dict = new Dictionary<string, string>();
                dict.Add("Content-Type", "application/x-www-form-urlencoded");

                dict.Add("client_id", client_id);
                dict.Add("grant_type", grant_type);
                dict.Add("resource", resource);
                dict.Add("username", username);
                dict.Add("password", password);
                dict.Add("scope", scope);
                dict.Add("client_secret", client_secret);

                using (var response = client.PostAsync(token_path, new FormUrlEncodedContent(dict)))
                {
                    if (!response.Result.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve tasks");
                    }

                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TokenResponse>(content);
                }
            }
        }
    }
}
