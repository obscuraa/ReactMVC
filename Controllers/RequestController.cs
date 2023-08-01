using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public RequestController(ILogger<RequestController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory.CreateLogger("MapLogger");
            _loggerFactory.LogInformation($"Path: /hello   Time: {DateTime.Now.ToLongTimeString()}");
        }

        private static List<Request> list = new List<Request>() { 
            new Request
            {
                ID = 1,
                X = 1,
                Y = 2,
                Z = 3
            },
        };

        [HttpPost]
        [Route("{id}")]
        public IActionResult CreateRequest(Request request, int id)
        {
            Random rand = new Random();

            double Xcoord  = rand.Next(1, 100);
            double Ycoord = rand.Next(1, 100);
            double Zcoord = rand.Next(1, 100);
            request.X = Xcoord;
            request.Y = Ycoord;
            request.Z = Zcoord;
            request.ID = id;

            return Ok(request);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneById(int id)
        {
            var reqModel = list.Find(x => x.ID == id);
            if (reqModel == null) return NotFound(id + " ID not found");
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddToList(Request request)
        {
            list.Add(request);
            return Ok(list);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, Request request)
        {
            var reqModel = list.Find(x => x.ID == id);
            if (reqModel == null) return NotFound(id+ " ID not found");

            reqModel.ID = request.ID;
            reqModel.X = request.X; 
            reqModel.Y = request.Y;
            reqModel.Z = request.Z;

            return Ok(list);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var reqModel = list.Find(x => x.ID == id);
            if (reqModel == null) return NotFound(id + " ID not found");

            list.Remove(reqModel);

            return Ok(list);
        }
    }
}
