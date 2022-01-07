
using Pipelines;

try
{
    await new ApplicationManager().Start();
}
catch (Exception exception)
{
    Console.WriteLine(exception);
}