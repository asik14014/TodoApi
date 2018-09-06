using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace DotNetCore.API1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //.NET CORE 2.1 way
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
