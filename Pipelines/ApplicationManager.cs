namespace Pipelines
{
    public class ApplicationManager
    {
        private readonly GetVariableGroupRepository _getVariableGroupRepository;
        private readonly VariableGroupsAnalyzerService _variableGroupsAnalyzerService;
        private const string _variableGroupUrl = Config.VariableGroupsUrl;
        private const string _releasesUrl = Config.ReleasesUrl;
        private const string _buildsUrl = Config.BuildsUrl;

        public ApplicationManager()
        {
            _getVariableGroupRepository = new GetVariableGroupRepository();
            _variableGroupsAnalyzerService = new VariableGroupsAnalyzerService();
        }
        private const string pat = Config.PersonalAccessToken;
        public async Task Start()
        {
            var path = Config.PathToSaveVariableGroups;
            var variableGroups = await _getVariableGroupRepository.Get(pat, _variableGroupUrl, path);

            var releasesPath = Config.PathToSaveReleaseDefinitions;
            var releases = await _getVariableGroupRepository.GetReleaseDefinitions(pat, _releasesUrl, releasesPath);

            var buildsPath = Config.PathToSaveBuildDefinitions;
            var builds = await _getVariableGroupRepository.GetBuildDefinitions(pat, _buildsUrl, buildsPath);

            _variableGroupsAnalyzerService
                .CheckThatVariableGroupsAreInUse(variableGroups, releases, builds);

            Console.WriteLine($"The number of Variable Groups: {variableGroups.Count}");
            Console.WriteLine($"The number of Builds: {builds.Count}");
            Console.WriteLine($"The number of Releases: {releases.Count}");
        }
    }
}