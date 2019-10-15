using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Bitrix24.Requests;
using Newtonsoft.Json;

namespace Bitrix24
{
    public class Bitrix24Client
    {
        private string _email;
        private string _password;
        protected string B24Address;

        private static readonly HttpClient _client = new HttpClient();

        public Bitrix24Client(string email, string password, string b24Address)
        {
            _email = email;
            _password = password;
            B24Address = b24Address;
        }


        public async Task<string> CreateLead(BitrixLead lead)
        {
            return await SendHttpPost(lead);
        }


        private async Task<string> SendHttpPost(IBitrixEntity bitrixEntity)
        {
            var values = bitrixEntity.ToDictionary();
            values.Add("LOGIN", _email);
            values.Add("PASSWORD", _password);

            var content = new FormUrlEncodedContent(values);
            var url = $"{B24Address}{bitrixEntity.GetMethod()}";
            var response = await _client.PostAsync(url , content);
            var responseString = await response.Content.ReadAsStringAsync();
            return GetIdFromResponse(responseString);
        }

        private string GetIdFromResponse(string responseString)
        {
            B24Response answer = JsonConvert.DeserializeObject<B24Response>(responseString);
            if (answer.error == "403")
                throw new AuthenticationException("Not Authorize");

            if (answer.error == "401")
                throw new AuthenticationException("Not Authorize");

            if (String.IsNullOrEmpty(answer.ID)) 
                throw new InvalidOperationException("There is no ID! Something was wrong! Response: " + responseString);

            return answer.ID;
        }
    }
}
