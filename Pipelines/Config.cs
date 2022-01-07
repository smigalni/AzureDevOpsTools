namespace Pipelines
{
    public static class Config
    {
        public const string PersonalAccessToken = "";
        public const string AzureDevOpsOrganizationName = "";
        public const string AzureDevOpsProjectId = "";
        public const string VariableGroupsUrl = $"https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/distributedtask/variablegroups/";
        public const string ReleasesUrl = $"https://vsrm.dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/Release/definitions/";

        public const string BuildsUrl = $"https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/build/definitions/";

        public static string PathToSaveVariableGroups = Path.Combine("C:", "Path", "Where", "yourSaveYour", "VariableGroup");
        public static string PathToSaveReleaseDefinitions = Path.Combine("C:", "Path", "Where", "yourSaveYour", "ReleaseDefinitions");
        public static string PathToSaveBuildDefinitions = Path.Combine("C:", "Path", "Where", "yourSaveYour", "BuildDefinitions");
    }
}
