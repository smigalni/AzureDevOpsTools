using Newtonsoft.Json;

namespace Pipelines
{
    public class JsonToPrettyJsonService
    {
        public string PrettyJson(string content)
        {
            var temp = JsonConvert.DeserializeObject(content);
            var prettyContent = JsonConvert.SerializeObject(temp, Formatting.Indented);
            return prettyContent;
        }
    }
}