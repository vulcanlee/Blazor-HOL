using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xfLab.Helpers.Constants;

namespace xfLab.Helpers.WebAPIs
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ConstantHelper.HTTPRequestPayload = "";
            ConstantHelper.HTTPRequestPayload = $"Request : {request.ToString()}{Environment.NewLine}{Environment.NewLine}";
            Debug.WriteLine(new String('-', 40));
            Debug.WriteLine("      " + "Request:");
            Debug.WriteLine("              " + request.ToString());
            if (request.Content != null)
            {
                Debug.WriteLine("              " + await request.Content.ReadAsStringAsync());
                ConstantHelper.HTTPRequestPayload += $"{await request.Content.ReadAsStringAsync()}{Environment.NewLine}";
            }
            Debug.WriteLine(new String('-', 40));
            Debug.WriteLine("");
            ConstantHelper.HTTPRequestPayload += $"{Environment.NewLine}{Environment.NewLine}";

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            ConstantHelper.HTTPRequestPayload += $"Response : {request.ToString()}";

            Debug.WriteLine(new String('-', 40));
            Debug.WriteLine("      " + "Response:");
            Debug.WriteLine("              " + response.ToString());
            if (response.Content != null)
            {
                Debug.WriteLine("              " + await response.Content.ReadAsStringAsync());
                ConstantHelper.HTTPRequestPayload += $"{await response.Content.ReadAsStringAsync()}{Environment.NewLine}";
            }
            Debug.WriteLine(new String('-', 40));
            Debug.WriteLine("");
            ConstantHelper.HTTPRequestPayload += $"{Environment.NewLine}{Environment.NewLine}";

            return response;
        }
    }
}
