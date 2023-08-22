using System.ComponentModel.DataAnnotations;

namespace Kibana.Rule.Engine.Models.RequestDto
{
    public class RequestDto
    {
        
        public int RuleId { get; set; }
      
        public string RuleName { get; set; }
        
        public string RuleType { get; set; }
     
        public string Severity { get; set; }
        public string KeyWord { get; set; }
      
        public string Email { get; set; }

    }
}
