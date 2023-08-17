using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RuleController : ControllerBase
    {
        private List<ISecurityRule> _rules;

        public RuleController()
        {
            InitializeRuleData();
        }
        private void InitializeRuleData()
        {
            _rules = new List<ISecurityRule>()
            {
                new SecurityRule(false, "Rule 1", "I/O", "High", "When the count of error is more than 10 from last 3 hours send notification to ...", "admin; supervisor" ),
                new SecurityRule(true, "Rule 2", "Communication", "High", "When the count of error is more than 2 from last 3 hours send notification to ...", "dev" ),
                new SecurityRule(false, "Rule 3", "I/O", "High", "When the count of error is more than 3 from last 3 hours send notification to ...", "tier-1-support" ),
                new SecurityRule(false, "Rule 4", "I/O", "High", "When the count of error is more than 0 from last 3 hours send notification to ...", "tier-3-support" ),
                new SecurityRule(false, "Rule 5", "Communication", "High", "When the count of error is more than 20 from last 3 hours send notification to ...", "admin; supervisor" ),
                new SecurityRule(true, "Rule 6", "I/O", "High", "When the count of error is more than 100 from last 12 hours send notification to ...", "admin; supervisor" ),
                new SecurityRule(true, "Rule 7", "Communication", "High", "When the count of error is more than 0 from last 36 hours send notification to ...", "ajay.kumar4@rockwellautomation.com;testuser4@email.com" ),
                new SecurityRule(false, "Rule 8", "Communication", "High", "When the count of error is more than 2 from last 3 hours send notification to ...", "ajay.kumar4@rockwellautomation.com;testuser5@email.com" ),
                new SecurityRule(false, "Rule 9", "I/O", "High", "When the count of error is more than 2 from last 3 hours send notification to ...", "admin; supervisor" ),
                new SecurityRule(true, "Rule 10", "I/O", "High", "When the count of error is more than 2 from last 3 hours send notification to ...", "admin; supervisor" ),


            };
        }

        [HttpGet]
        public async Task<IActionResult> GetRule()
        {
           return new JsonResult(_rules);

        }
    }
}
