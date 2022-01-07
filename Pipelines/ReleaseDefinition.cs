namespace Pipelines
{
    public class ReleaseDefinition
    {
        public ReleaseDefinition()
        {
            VariableGroups = new List<int>();
            Environments = new List<Environment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<int> VariableGroups { get; set; }
        public List<Environment> Environments { get; set; }
    }
    public class Environment
    {
        public Environment()
        {
            VariableGroups = new List<int>();
        }
        public int Id { get; set; }
        public List<int> VariableGroups { get; set; }
    }
}
