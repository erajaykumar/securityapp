using Kibana.Rule.Engine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nest;
using Newtonsoft.Json;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;

namespace Kibana.Rule.Engine.Controllers
{
   
    public class ElasticController : Controller
    {
      
        private readonly IElasticClient _elasticClient;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ElasticController(IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment)
        {
            _elasticClient = elasticClient;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Index(string keyword)
        {

            var eventList = new List<EventModel>();
            if (!string.IsNullOrEmpty(keyword))
            {
                eventList = GetSearch(keyword).ToList();
            }

            return View(eventList.AsEnumerable());
        }

        public IList<EventModel> GetSearch(string keyword)
        {
            var result = _elasticClient.SearchAsync<EventModel>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                    )).Size(5000));

            var finalResult = result;
            var finalContent = finalResult.Result.Documents.ToList();
            return finalContent;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var sevrity = new List<SelectListItem>()
            {
                new SelectListItem{Text="Major",Value="major"},
                new SelectListItem {Text="Minor",Value="minor" }
                
            };
            ViewBag.severity = sevrity;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventModel model)
        {
            try
            {
                var eventList = new EventModel()
                {
                    FaultId=model.FaultId,
                    FaultCode=model.FaultCode,
                    FaultType=model.FaultType,                    
                    DisplayText=model.DisplayText,
                    Fault = model.Fault,
                    Severity=model.Severity,
                    @timestamp= DateTime.UtcNow,
            };

             await _elasticClient.IndexDocumentAsync(eventList);
              
                model = new EventModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EventModel model)
        {
            try
            {
                var eventList = new EventModel()
                {
                    FaultId = model.FaultId,
                    FaultCode = model.FaultCode,
                    FaultType = model.FaultType,
                    DisplayText = model.DisplayText,
                    Fault = model.Fault,
                    Severity = model.Severity
                };

                await _elasticClient.DeleteAsync<EventModel>(eventList);
                model = new EventModel();
            }
            catch (Exception ex)
            {
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Import()
        {
            var demo = new LogUtility.Logger();
            try
            {
                var rootPath = _hostingEnvironment.ContentRootPath; //get the root path

                var fullPath =
                    Path.Combine(rootPath, "SampleData.Json");

                var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file

                var articleList = JsonConvert.DeserializeObject<List<EventModel>>(jsonData);
                if (articleList != null)
                {
                    foreach (var article in articleList)
                    {
                        _elasticClient.IndexDocumentAsync(article);
                    }
                }
            }
            catch (Exception ex)
            {
                demo.Error(ex.Message);
            }

            return RedirectToAction("Index");
        }

    }
}
