namespace Pipelines
{
    public class GetVariableGroupRepository
    {
        private readonly JsonSerializerService _jsonSerializerService;
        private readonly HttpClientService _httpClientService;
        private readonly SaveToDiskService _saveToDiskService;
        public GetVariableGroupRepository()
        {
            _jsonSerializerService = new JsonSerializerService();
            _httpClientService = new HttpClientService();
            _saveToDiskService = new SaveToDiskService();
        }

        public async Task<List<Result>> Get(string pat, string url, string pathToSave)
        {
            var result = new List<Result>();

            var content = await HttpClientService.Get(pat, url);

            var objectDto = _jsonSerializerService.Deserialize<ObjectDto>(content);

            result.AddRange(objectDto.Value);

            foreach (var item in result)
            {
                var contentVariableGroup = await HttpClientService.Get(pat, url, item.Id);
                var path = Path.Combine(pathToSave, item.Name);
                _saveToDiskService.Save(path, contentVariableGroup);
            }
            return result;
        }
        public async Task<List<ReleaseDefinition>> GetReleaseDefinitions(string pat, string url, string pathToSave)
        {
            var result = new List<Result>();
            var releaseDefinitions = new List<ReleaseDefinition>();

            var content = await HttpClientService.Get(pat, url);

            var objectDto = _jsonSerializerService.Deserialize<ObjectDto>(content);

            result.AddRange(objectDto.Value);

            foreach (var item in result)
            {
                var contentVariableGroup = await HttpClientService.Get(pat, url, item.Id);

                releaseDefinitions.Add(_jsonSerializerService.Deserialize<ReleaseDefinition>(contentVariableGroup));
                var path = Path.Combine(pathToSave, item.Name);
                _saveToDiskService.Save(path, contentVariableGroup);
            }
            return releaseDefinitions;
        }
        public async Task<List<BuildDefinition>> GetBuildDefinitions(string pat, string url, string pathToSave)
        {
            var result = new List<Result>();
            var buildsDefinitions = new List<BuildDefinition>();

            var content = await HttpClientService.Get(pat, url);

            var objectDto = _jsonSerializerService.Deserialize<ObjectDto>(content);

            result.AddRange(objectDto.Value);

            foreach (var item in result)
            {
                var contentVariableGroup = await HttpClientService.Get(pat, url, item.Id);

                buildsDefinitions.Add(_jsonSerializerService.Deserialize<BuildDefinition>(contentVariableGroup));
                var path = Path.Combine(pathToSave, item.Name);
                _saveToDiskService.Save(path, contentVariableGroup);
            }
            return buildsDefinitions;
        }
    }
}