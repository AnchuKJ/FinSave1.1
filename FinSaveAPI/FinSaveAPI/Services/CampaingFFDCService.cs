using FinSaveAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinSaveAPI.Services
{
    public class CampaingFFDCService
    {
        public async Task<string> GetFFDCTocken()
        {
            try
            {
                var token = "";
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://api.fusionfabric.cloud/login/v1/sandbox/oidc/token");
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                        { "client_id", "94971381-fd8a-4183-8311-decebc7bbf36" },
                        { "client_secret", "90d61ed4-b8fd-48b4-a680-3ffec9a28d1b" },
                        { "grant_type", "client_credentials" }
                    });
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
                    token = payload.Value<string>("access_token");
                }
                return token;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public async Task<ActionResult> LoginUser(string user)
        {
            var result = "";
            string consumerId = "01010OA00P200";
            var token = GetFFDCTocken().Result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.fusionfabric.cloud/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("X-Request-ID", "6d1a09f9-eeb0-4c17-a21a-b82b28e117f7");
                result = await client.GetStringAsync($"/retail-us/customer-read/v1/consumers/{consumerId}");
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult> PerformTransaction(string consumerId, TransactArgs args)
        {
            string str = JsonConvert.SerializeObject(args);
            HttpResponseMessage result;
            var token = GetFFDCTocken().Result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.fusionfabric.cloud/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpContent httpContent = new StringContent(str, Encoding.UTF8, "application/json");
                //HttpContent cont = new HttpContent();
                result = await client.PostAsync($"/retail-us/internal-transfers/v1/consumers/{consumerId}/internal-transfers", httpContent);
            }
            return new OkObjectResult(result);
}

        public async Task<ActionResult> GetUserTransactions(string from, string to, string accountId)
        {
            var result = "";
            var token = GetFFDCTocken().Result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.fusionfabric.cloud/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                result = await client.GetStringAsync($"/retail-banking/accounts/v1/accounts/{accountId}/transactions?startDate={from}&endDate={to}&limit=100&offset=0");
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult> GetUserAccounts(string UserId)
        {
            FFDCAccounts accs;
            var result = "";
            var token = GetFFDCTocken().Result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.fusionfabric.cloud/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); 
                result = await client.GetStringAsync($"/retail-banking/accounts/v1/accounts?customerId={UserId}");
                accs = JsonConvert.DeserializeObject<FFDCAccounts>(result);//JsonSerializer.Deserialize< FFDCAccount>(result);
                
            }
            foreach (FFDCAccount item in accs.Accounts)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.fusionfabric.cloud/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //https://api.preprod.fusionfabric.cloud/retail-us/account/v1/consumers/{consumerId}/accounts/{accountId}
                    result = await client.GetStringAsync($"/retail-us/account/v1/consumers/{UserId}/accounts/{item.accountId}");
                    accs = JsonConvert.DeserializeObject<FFDCAccounts>(result);//JsonSerializer.Deserialize< FFDCAccount>(result);

                }
            }
            return new OkObjectResult(result);
        }
    }


}
