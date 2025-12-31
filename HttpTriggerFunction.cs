using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Company.FunctionApp
{
    public class HttpTriggerFunction
    {
        private readonly ILogger<HttpTriggerFunction> _logger;

        public HttpTriggerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTriggerFunction>();
        }

        [Function("HttpTriggerFunction")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "hello")] HttpRequestData req)
        {
            _logger.LogInformation("HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Hello from my demo function running on .NET 8 isolated!");

            return response;
        }
    }
}
