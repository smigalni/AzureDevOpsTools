using System.Text.Json;

namespace Pipelines
{
    public class JsonSerializerService
    {
        public T Deserialize<T>(string content)
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
            var result = JsonSerializer.Deserialize<T>(content, options);
            return result;
        }
    }
}