using Microsoft.AspNetCore.Mvc;
using ReactMVC.Models;

namespace ReactMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly Logic _logic;
        private readonly Request _request;
        private readonly ILogger _loggerFactory;

        public RequestController(ILogger<RequestController> logger, ILoggerFactory loggerFactory, Logic logic, Request request)
        {
            _logger = logger;
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
                var Rglobal = request.Rglobal;
                var FilesNumber = request.FilesNumber;

                var sphere = new Sphere(1, 2, 3, 4);
            
                var ListOfPoints = _logic.GenerateRandomPoints(sphere, 3);
                // параметр NumOfFiles должен быть меньше чем кол-во элементов в списке, иначе System.ArgumentOutOfRangeException
                _logic.ThreadablePrintEllipsoidFields(ListOfPoints, ListOfPoints.Count - 1);

                Response response = new()
                {
                    Status = true,
                    Message = "Sending message",
                    Data = "message"
                };

                return Ok(response);
            }
            catch (Exception ex){
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("download")]
        public ActionResult DownloadDocument()
        {
            string filePath = "/Files";
            string fileName = "data.txt";

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "Files/force-download", fileName);
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