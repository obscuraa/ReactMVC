using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactMVC.Models;
using System.Collections;

namespace ReactMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly ILogger _loggerFactory;
        private readonly Random rand = new();

        public RequestController(ILogger<RequestController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory.CreateLogger("MapLogger");
            _loggerFactory.LogInformation($"Path: /hello   Time: {DateTime.Now.ToLongTimeString()}");
        }

        private static List<Request> list = new List<Request>() { 
            new Request
            {
                X = 1,
                Y = 2,
                Z = 3
            }
        };

        [HttpPost]
        public IActionResult CreateRequest(Request request)
        {
            try
            {
                double Xcoord = RandomizeCoordinate();
                double Ycoord = rand.NextDouble() * 2 - 1;
                double Zcoord = rand.NextDouble() * 2 - 1;
                request.X = Xcoord;
                request.Y = Ycoord;
                request.Z = Zcoord;

                list.Add(request);

                return Ok(request);
            }
            catch (Exception ex){
                _logger.LogError(ex, "An error occurred in CreateRequest method");
                ex.ToString();
                throw;
            }
        }

        private double RandomizeCoordinate()
        {
            return rand.NextDouble() * 2 - 1;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetAll method");
                ex.ToString();
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddToList(Request request)
        {
            try
            {
                list.Add(request);
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in AddToList method");
                ex.ToString();
                throw;
            }
        }
    }
}
