using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View();
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
                
            }
            return Ok();
        }

        // GET: RuleDbController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RuleDbController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RuleDbController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RuleDbController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
