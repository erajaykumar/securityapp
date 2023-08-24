using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rule.Create.Service.Models;
using System;
using System.Reflection;

namespace Rule.Create.Service.Controllers
{
    public class RuleDbController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IDataAccessProvider _dataAccessProvider;

        

        public RuleDbController(IDataAccessProvider dataAccessProvider, IWebHostEnvironment hostingEnvironment)
        {
            _dataAccessProvider = dataAccessProvider;            
            _hostingEnvironment = hostingEnvironment;

        }
        // GET: RuleDbController
        public ActionResult Index()
        {
            var eventList = _dataAccessProvider.GetRules();
            return Ok(eventList);
            
        }

        // GET: RuleDbController/Details/5
        public ActionResult Details(int id)
        {
           var ruleDetail= _dataAccessProvider.GetRule(id);
            return Ok(ruleDetail);
        }

      

        // GET: RuleDbController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RuleDbController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rules model)
        {
            
            var lastRuleId = _dataAccessProvider.GetRules().Select(r => r.RuleId).LastOrDefault();
            int id = lastRuleId + 1;
            PostData p = new PostData { Id = id, Message = "Created" };

            Rules rules = new()
            {
                RuleId = id,
                RuleName = model.RuleName,
                RuleType = model.RuleType,
                Severity = model.Severity,
                KeyWord = model.KeyWord,
                timestamp = DateTime.UtcNow,
                Email = model.Email,
                CountOfKeyword = model.CountOfKeyword,
                FromDuration = model.FromDuration,
                DurationNotaion = model.DurationNotaion
            };
            if (ModelState.IsValid)
            {
                _dataAccessProvider.CreateRules(rules);
                LogMethod().Info("rule save in db");
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:708/");
                    var response = client.PostAsJsonAsync("Producer/send?topic=demo", p).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        LogMethod().Info("Success");
                    }
                    else
                        LogMethod().Error("Success");
                }

            }
             return Ok();
        }

       
       
        public static Logger LogMethod()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
            var demo = new Logger();
            return demo;
        }
    }
}
