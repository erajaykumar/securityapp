namespace SecurityApp.API.Model
{
    public class SecurityRule : ISecurityRule
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public string Logic { get; set; }
        public string Notification { get; set; }

        public SecurityRule(bool enabled, string name, string type, string severity, string logic, string notification)
        {
            this.Enabled = enabled;
            this.Name = name;
            this.Type = type;
            this.Severity = severity;
            this.Logic = logic;
            this.Notification = notification;
        }
    }
}
