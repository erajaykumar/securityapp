using Kibana.Rule.Engine.Models;
using Kibana.Rule.Engine.Models.RequestDto;
using log4net.Config;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Nest;
using Rule.Engine.Kibana;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using log4net;
namespace Kibana.Rule.Engine.Controllers
{
    [Authorize]
    public  class RuleController : Controller
    {
        private readonly IElasticClient _elasticClient;
        private readonly IWebHostEnvironment _hostingEnvironment;
      
        private readonly IDataAccessProvider _dataAccessProvider;
       

        public RuleController(IDataAccessProvider dataAccessProvider, IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment)
        {
            _dataAccessProvider = dataAccessProvider;
            _elasticClient = elasticClient;
            _hostingEnvironment = hostingEnvironment;
        }
         
         
        
       
        public IActionResult Index()
        {
            LogToken();
            var eventList = _dataAccessProvider.GetRules();
            return View(eventList);
          
        }
        public async Task LogToken()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Console.WriteLine($"identity token {identityToken}");
           
                
        }
        
        [HttpGet]        
        public ActionResult Create()
        {
            //var demo = LogMethod();
            //demo.Debug("create started");

            var number = new List<SelectListItem>()
            {
                new SelectListItem{Text="1",Value="1"},
                new SelectListItem {Text="2",Value="2" },
                new SelectListItem {Text="3",Value="3" },
                new SelectListItem {Text="4",Value="4" },
                new SelectListItem {Text="5",Value="5" },
                new SelectListItem {Text="6",Value="6" }
            };
            var notation = new List<SelectListItem>()
            {
                new SelectListItem{Text="m",Value="m"},
                new SelectListItem {Text="h",Value="h" }
          
            };
            var keywords = new List<SelectListItem>()
            {
                new SelectListItem{Text="count of error",Value="error"},
                new SelectListItem {Text="count of warning",Value="warning" }
               
            };
            var sevrity = new List<SelectListItem>()
            {
                new SelectListItem{Text="Major",Value="major"},
                new SelectListItem {Text="Minor",Value="minor" }

            };
            ViewBag.severity = sevrity;
            ViewBag.keyword = keywords;
            ViewBag.List = number;
            ViewBag.time = number;
            ViewBag.timenotation = notation;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rules model)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
            var demo = new LogUtility.Logger();
            demo.Info("rule creation started");
            
            var number = new List<SelectListItem>()
            {
                new SelectListItem{Text="1",Value="1"},
                new SelectListItem {Text="2",Value="2" },
                new SelectListItem {Text="3",Value="3" },
                new SelectListItem {Text="4",Value="4" },
                new SelectListItem {Text="5",Value="5" },
                 new SelectListItem {Text="6",Value="6" }
            };
            var notation = new List<SelectListItem>()
            {
                new SelectListItem{Text="min",Value="m"},
                new SelectListItem {Text="hour",Value="h" }

            };
            var keywords = new List<SelectListItem>()
            {
                new SelectListItem{Text="count of error",Value="error"},
                new SelectListItem {Text="count of warning",Value="warning" }

            };
            var sevrity = new List<SelectListItem>()
            {
                new SelectListItem{Text="Major",Value="major"},
                new SelectListItem {Text="Minor",Value="minor" }

            };
            ViewBag.severity = sevrity;
            ViewBag.keyword = keywords;
            ViewBag.List = number;
            ViewBag.time = number;
            ViewBag.timenotation = notation;
            var lastRuleId = _dataAccessProvider.GetRules().Select(r=>r.RuleId).LastOrDefault();
            int id = lastRuleId + 1;
            Rules rules = new()
            { 
                RuleId = id,
                RuleName = model.RuleName,
                RuleType = model.RuleType,
                Severity = model.Severity,
                KeyWord = model.KeyWord,
                timestamp= DateTime.UtcNow,
                Email = model.Email,
                CountOfKeyword  = model.CountOfKeyword,
                FromDuration = model.FromDuration,
                DurationNotaion = model.DurationNotaion
            };
            if (ModelState.IsValid)
            {               
                _dataAccessProvider.CreateRules(rules);
               await CreateRuleAsync(rules);
                demo.Info("rule created in db with id" + id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public  async Task CreateRuleAsync(Rules rules)
        {

           
            var endpointUrl = "https://9f1dc834302048388a92068e1365a3ea.us-central1.gcp.cloud.es.io:9243/api/detection_engine/rules";
            string username = "elastic";
            string password = "dKdQIV4S1mVszIuvcDJIWxnA";
            string index = "logdata";
            string alertmsg = @"Hi,\n\n No of Alerts : {{alerts.new.count}} \n Data : {{alerts.new.data}} \n\n Thank you,Intelligent Security System Team";
            string alertSubject = "Alert from Kibana!!";
            string duration=$"now-{rules.FromDuration}{rules.DurationNotaion}";
            if (rules.Severity == "major" || rules.Severity=="MOJOR")
            {
                rules.Severity = "high";
            }
            else
            {
                rules.Severity = "low";
            }
            string alertPayload = "{\"index\":[\"" + index + "\"],\"rule_id\": \"" + rules.RuleId + "\",\"risk_score\": 50,\"description\": \"" + rules.RuleName + "\",\"interval\": \"1m\",\"name\": \"" + rules.RuleName+ "\",\"severity\": \"" + rules.Severity + "\",\"tags\":[\"test\"], \"type\": \"query\",\"from\": \"" + duration + "\",\"filters\":[{\"query\":{\"match\": {\"DisplayText\": \"" + rules.KeyWord + "\"}}}],\"enabled\": true,\"actions\":[]}";
            string alertPayloadCount = "{\"index\":[\"" + index + "\"],\"rule_id\": \"" + rules.RuleId + "\",\"risk_score\": 50,\"description\": \"" + rules.RuleName + "\",\"interval\": \"1m\",\"name\": \""+rules.RuleName+"\",\"severity\": \"" + rules.Severity + "\",\"tags\":[\"test\"], \"type\": \"query\",\"from\": \"" + duration + "\",\"filters\":[{\"query\":{\"match\": {\"DisplayText\": \"" + rules.KeyWord + "\"}}}],\"enabled\": true,\"actions\": [{\"action_type_id\":\".email\",\"group\": \"default\",\"id\": \"elastic-cloud-email\",\"params\": {\"message\": \"" + alertmsg + "\",\"to\": [\"" + rules.Email + "\"],\"subject\": \"" + alertSubject + "\"},\"frequency\":{\"notifyWhen\": \"onActiveAlert\",\"throttle\": \"1m\",\"summary\": true}}]}";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password)));
                httpClient.DefaultRequestHeaders.Add("kbn-xsrf","true");
                int count = GetSearch(rules.KeyWord);
                
                if ((count) > rules.CountOfKeyword)
                {
                   var requestContent = new StringContent(alertPayloadCount, Encoding.UTF8, "application/json");
                    var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpointUrl);
                    httpRequest.Content = requestContent;
                    var response = await httpClient.SendAsync(httpRequest);
                }
                else
                {
                    var requestContent = new StringContent(alertPayload, Encoding.UTF8, "application/json");
                    var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpointUrl);
                    httpRequest.Content = requestContent;
                    var response = await httpClient.SendAsync(httpRequest);
                }
                
               

            }

        }

        public  int GetSearch(string keyword)
        {
            var result = _elasticClient.SearchAsync<Rules>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                    )).Size(500));

            var finalResult = result;
            var finalcount = finalResult.Result.Documents.ToList().Count;
            return finalcount;
        }

    }
}
