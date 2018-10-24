using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Monapay.Net.Helpers
{
    internal class BaseClient
    {
        internal static async Task<string> PostEntities(string urlLink, string content, string secretKey)
        {
            HttpClient httpClient = HttpConnection.CreateClient(secretKey);
            HttpResponseMessage httpResponse = await httpClient.PostAsync(urlLink, new StringContent(content, Encoding.UTF8, Constants.ContentTypeHeaderJson));
            return await httpResponse.Content.ReadAsStringAsync();
        }
        internal static async Task<string> GetEntities(string urlLink, string secretKey)
        {
            HttpClient client = HttpConnection.CreateClient(secretKey);
            Task<HttpResponseMessage> response = client.GetAsync(urlLink);
            string content = await response.Result.Content.ReadAsStringAsync();
            return content;
        }
        internal static async Task<string> PutEntities(string urlLink, string content, string secretKey)
        {
            HttpClient client = HttpConnection.CreateClient(secretKey);
            HttpResponseMessage response = await client.PutAsync(urlLink, new StringContent(content, Encoding.UTF8, Constants.ContentTypeHeaderJson));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
