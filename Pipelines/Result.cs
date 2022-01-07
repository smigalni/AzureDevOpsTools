namespace Pipelines
{
    public class ObjectDto
    {
        public int Count { get; set; }
        public List<Result> Value { get; set; }
    }
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
