using System.Net.Http;
using System.Web.Http;
using CodeCamp2013.WebApi.Mesagehandlers;
using Xunit;

namespace CodeCamp2013.WebApi.Tests
{
    public class CustomHeaderHandlerTests
    {
        [Fact]
        public void Added_Custom_Header_To_Response()
        {
            var config = new HttpConfiguration();
            config.MessageHandlers.Add(new CustomHeaderHandler());
            using (var server = WebApiTestHelper.ConfigureServer(config))
            {
                var client = new HttpClient(server);
                using (var response = client.GetAsync("http://localhost/api/events/list").Result)
                {
                    Assert.True(response.Headers.Contains("X-SFLCC-Header"));
                }
            }
        }
    }
}