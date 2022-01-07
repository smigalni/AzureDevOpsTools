using System.Net.Http.Headers;

namespace Pipelines
{
    public class HttpClientService
    {
        public static async Task<string> Get(string pat, string url)
        {
            return await GetResult(pat, url);
        }

        public static async Task<string> Get(string pat, string url, int id)
        {
            var urlWithId = $"{url}{id}";

            return await GetResult(pat, urlWithId);
        }
        private static async Task<string> GetResult(string pat, string url)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "", pat))));
            string content;
            using (var response = await client.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();
            }
            return content;
        }
    }
}