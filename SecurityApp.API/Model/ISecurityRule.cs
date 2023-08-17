namespace SecurityApp.API.Model
{
    public interface ISecurityRule
    {
        bool Enabled { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Severity { get; set; }
        string Logic { get; set; }
        string Notification { get; set; }
    }
}
