namespace Pipelines
{
    public class SaveToDiskService
    {
        private JsonToPrettyJsonService _jsonToPrettyJson;
        public SaveToDiskService()
        {
            _jsonToPrettyJson = new JsonToPrettyJsonService();
        }
        public void Save(string path, string content)
        {
            var prettyContent = _jsonToPrettyJson.PrettyJson(content);
            File.WriteAllText($"{path}.json", prettyContent);
        }
    }
}