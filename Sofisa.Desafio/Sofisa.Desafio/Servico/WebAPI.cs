using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sofisa.Desafio.Servico
{
    public class WebAPI
    {
        public async Task<List<T>> GetListAPIAsync<T>(string endPointURL)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(endPointURL);

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<T>>(retorno);
                    }
                    else
                    {
                        return default;
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

        }
        public async Task<T> GetAPIAsync<T>(string endPointURL)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(endPointURL);

                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(retorno);
                }
                else
                {
                    return default;
                }
            }
        }

        public async Task<T> DeleteAPIAsync<T>(string endPointURL)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(endPointURL);

                if (response.IsSuccessStatusCode)
                {
                    var retorno = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(retorno);
                }
                else
                {
                    return default;
                }
            }
        }
        public async Task<T> PostAPIAsync<T>(string endPointURL, T obj)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonContent = JsonConvert.SerializeObject(obj);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(endPointURL, contentString);

                if (response.IsSuccessStatusCode)
                {
                    string retorno = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(retorno);
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
