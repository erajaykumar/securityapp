using Nest;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kibana.Rule.Engine.Models
{
    public class Rules
    {

        [Key]
        public int RuleId { get; set; }
        [Required]
        public string RuleName { get; set; }
        [Required]
        public string RuleType { get; set; }
        [Required]
        public string Severity { get; set; }
        public string KeyWord { get; set; }
        public DateTime @timestamp { get; set; }
        public string Email { get; set; } 

        public int CountOfKeyword { get; set; }
        public int  FromDuration{ get; set; }
        public string  DurationNotaion { get; set; }


    }
}
