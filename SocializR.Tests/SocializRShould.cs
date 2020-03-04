using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SocializR.Tests
{
    public class SocializRShould
    {
        [Fact]
        public async Task RenderApplicationForm()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(@"C:\Users\mihai.podaru\source\repos\SocializR\SocializR")
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            var client = server.CreateClient();

            var response = await client.GetAsync("/Account/Register");

            //response.EnsureSuccessStatusCode();

           // var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
