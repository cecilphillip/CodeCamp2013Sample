using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CodeCamp2013.WebApi.Mesagehandlers
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith((task) =>
                {
                    var response = task.Result;
                    response.Headers.Add("X-SFLCC-Header", "This is my custom header.");
                    return response;
                }
            );
        }
    }
}