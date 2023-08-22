
using Kibana.Rule.Engine.Models.RequestDto;
using System.Reflection.Metadata;
using System.Text;

namespace Kibana.Rule.Engine
{
    public static class ElkRule
    {
        public static async Task CreateRuleAsync(this IServiceCollection services, IConfiguration configuration)
        {
            
           RequestDto rules = new RequestDto();
            var endpointUrl = configuration["AppConfig:KibanaURL"];
            string Username = "elastic";
            string Password = "JzlhQrPawisy2JRNrFMzwneR";
            string index = configuration["AppConfig:Index"];
            string alertmsg = "ALERT!!!!!! Please verify if all logs are from known source";
            string alertSubject = "Alert from Kibana!!";
            string severity=null;
            string duration=null;
            if (rules.Severity=="major")
            {
                severity = "high";
            }
            else
            {
                severity = "low";
            }
            string alertPayload = "{\"index\":[\"" + index + "\"],\"rule_id\": \"" + rules.RuleId + "\",\"risk_score\": 50,\"description\": \"" + rules.RuleName + "\",\"interval\": \"5m\",\"name\": \"Test Rules\",\"severity\": \"" + severity + "\",\"tags\":[\"test\"], \"type\": \"query\",\"from\": \"" + duration + "\",\"filters\":[{\"query\":{\"match\": {\"message\": \"" + rules.KeyWord + "\"}}}],\"enabled\": true,\"actions\": [{\"action_type_id\":\".email\",\"group\": \"default\",\"id\": \"elastic-cloud-email\",\"params\": {\"message\": \"" + alertmsg + "\",\"to\": [\"nehakumari199460@gmail.com\"],\"subject\": \"" + alertSubject + "\"},\"frequency\":{\"notifyWhen\": \"onActiveAlert\",\"throttle\": \"rule\",\"summary\": true}}]}";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(Username + ":" + Password)));
                httpClient.DefaultRequestHeaders.Add("kbn-xsrf", "true");
                var requestContent = new StringContent(alertPayload, Encoding.UTF8, "application/json");
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpointUrl);
                httpRequest.Content = requestContent;
                var response = await httpClient.SendAsync(httpRequest);
                if (response.IsSuccessStatusCode)
                {
                   
                }
                else
                {
                    
                }
            }

        }
    }
}
