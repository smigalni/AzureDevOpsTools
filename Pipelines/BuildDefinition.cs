namespace Pipelines
{
    public class BuildDefinition
    {
        public BuildDefinition()
        {
            VariableGroups = new List<VariableGroup>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<VariableGroup> VariableGroups { get; set; }
    }

    public class VariableGroup
    {
        public int Id { get; set; }
    }
}
