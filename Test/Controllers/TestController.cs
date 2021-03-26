using Test.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITransactionService _transactionServ;
        private readonly ILogger<TestController> _logger;

        public TestController(ITransactionService transactionServ, ILogger<TestController> logger)
        {
            _transactionServ = transactionServ;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int? input)
        {
            _logger.LogInformation($"Input: {input}");
            var result = _transactionServ.GetLetters(input);
            _logger.LogInformation($"result: {result}");

            return new JsonResult(result);
        }
    }
}
