using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int? input)
        {
            _logger.LogInformation($"Input: {input}");
            var result = new TransactionService().GetLetters(input);
            _logger.LogInformation($"result: {result}");

            return new JsonResult(result);
        }
    }
}
