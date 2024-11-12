using LM.Core.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LeaveManagement.Auth
{
    public static class TokenManager
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> GetToken(string url, Users requestDto)
        {
            string responseString, token = "";
            try
            {

                // Serialize request DTO to JSON
                string jsonPayload = JsonConvert.SerializeObject(requestDto);
                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Create HTTP POST request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content); // POstAsync

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                responseString = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<string>(responseString);
            }
            catch (Exception ex)
            {
                //Response.Write("<script>" + "alert(Api Call is Failed  )" + "</script>");
                //Response.Write("<pre>" + ex.ToString() + "</pre>");
                //Log.LogMsg(ex.ToString());
                return "";

            }
            // Deserialize the response into ResponseDTO
            return token;
        }
    }
}