using StripsClientWPFReeksView.Exceptions;
using StripsClientWPFReeksView.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        private HttpClient client;

        public StripServiceClient()
        {
            client = new();
            client.BaseAddress = new("http://localhost:5044");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Reeks> GetReeksAsync(string path)
        {
            try
            {
                Reeks? reeks = null;

                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    reeks = await response.Content.ReadAsAsync<Reeks>();
                }

                return reeks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
