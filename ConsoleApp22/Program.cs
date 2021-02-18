using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var task1 = new ChromeDriverTestTask();
            task1.Execute();

            //Bonus: using Docker.Dotnet lib 
            //var task2 = new DockerDotNetTask();
            //await task2.ExecuteAsync();
        }
    }
}




