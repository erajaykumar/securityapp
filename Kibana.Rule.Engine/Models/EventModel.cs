namespace Kibana.Rule.Engine.Models
{
    public class EventModel
    {
        public int FaultId { get; set; }

        public string FaultCode { get; set; }
        public string FaultType { get; set; }
        public string DisplayText { get; set; }
        public string Fault { get; set; }
        public string Severity { get; set; }
        public DateTime @timestamp  { get; set; }

    }
}
