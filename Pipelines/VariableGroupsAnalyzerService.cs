namespace Pipelines
{
    public class VariableGroupsAnalyzerService
    {
        public void CheckThatVariableGroupsAreInUse(List<Result> variableGroups,
            List<ReleaseDefinition> releases,
            List<BuildDefinition> builds
            )
        {
            foreach (var variableGroup in variableGroups)
            {
                var notInUsevariableGroups = new List<int>();
                notInUsevariableGroups.AddRange(releases
                    .SelectMany(item => item.VariableGroups.Where(item => item == variableGroup.Id)));

                notInUsevariableGroups.AddRange(releases
                    .SelectMany(item => item.VariableGroups.Where(item => item == variableGroup.Id)));

                notInUsevariableGroups.AddRange(builds
                     .SelectMany(item => item.VariableGroups.Where(item => item.Id == variableGroup.Id)).Select(item => item.Id));

                notInUsevariableGroups.AddRange(releases
                    .SelectMany(item => item.Environments
                        .SelectMany(item => item.VariableGroups
                            .Where(item => item == variableGroup.Id))));

                if (!notInUsevariableGroups.Any())
                {
                    Console.WriteLine($"Variable group {variableGroup.Name} is not in use in any Release. Can be removed");
                }
            }
        }
    }
}
