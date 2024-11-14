using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EShopFunction
{
    public class HttpOrder
    {
        private readonly ILogger<HttpOrder> _logger;

        public HttpOrder(ILogger<HttpOrder> logger)
        {
            _logger = logger;
        }

        [Function("HttpOrder")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
