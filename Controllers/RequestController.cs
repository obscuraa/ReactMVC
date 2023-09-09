using Microsoft.AspNetCore.Mvc;
using ReactMVC.Models;

namespace ReactMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly Sphere _sphere;
        private readonly Logic _logic;
        private readonly Request _request;
        private readonly ILogger _loggerFactory;

        public RequestController(ILogger<RequestController> logger, ILoggerFactory loggerFactory, Sphere sphere, Logic logic, Request request)
        {
            _logger = logger;
            _sphere = sphere;
            _logic = logic;
            _request = request;
            _loggerFactory = loggerFactory.CreateLogger("MapLogger");
            _loggerFactory.LogInformation($"Path: /hello   Time: {DateTime.Now.ToLongTimeString()}");
        }

        //private static List<Request> list = new List<Request>() { 
        //    new Request
        //    {
        //        Number = 1,
        //        Rglobal = 2,
        //        FilesNumber = 3
        //    }
        //};

        [HttpPost("create")]
        public IActionResult CreateRequest(Request request)
        {
            try
            {
                Response response = new Response();
                response.Status = true;
                response.Message = "Sending message";
                response.Data = "message";

             

                var Rglobal = request.Rglobal;
                var FilesNumber = request.FilesNumber;


               // var area = new Wrapper();
            

                var ListOfPoints = _logic.GenerateRandomPoints(_sphere, 10);
                _logic.ThreadablePrintEllipsoidFields(ListOfPoints, 5);
                
                return Ok(response);
            }
            catch (Exception ex){
                _logger.LogError(ex, "An error occurred in CreateRequest method");
                ex.ToString();
                throw;
            }
        }

        //private double RandomizeCoordinate()
        //{
        //    return rand.NextDouble() * 2 - 1;
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred in GetAll method");
        //        ex.ToString();
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public IActionResult AddToList(Request request)
        //{
        //    try
        //    {
        //        list.Add(request);
        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred in AddToList method");
        //        ex.ToString();
        //        throw;
        //    }
        //}
    }
}






//Homework
/*
 * cub
 * sp
 * cil
 
aRea(size R)


metanit патерн стратегия





