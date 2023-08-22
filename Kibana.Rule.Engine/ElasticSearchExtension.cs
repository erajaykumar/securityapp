
using Kibana.Rule.Engine.Models;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using Nest;
using System.Reflection;

namespace ElasticSearch
{
    public static class ElasticSearchExtension
    {
        public static LogUtility.Logger LogMethod()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));
            var demo = new LogUtility.Logger();
            return demo;
        }
      


        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var demo = LogMethod();
            try
            {
                var baseUrl = configuration["ElasticSettings:baseUrl"];
                var index = configuration["ElasticSettings:defaultIndex"];
                var password = configuration["ElasticSettings:password"];

                var settings = new ConnectionSettings(new Uri(baseUrl))
                    .PrettyJson()
                    //.CertificateFingerprint("A2525B64D8BFD084D946539261844AC9A3F7DBDC")
                    .BasicAuthentication("elastic",password)
                    .DefaultIndex(index);
                settings.EnableApiVersioningHeader();


                var client = new ElasticClient(settings);
                
                services.AddSingleton<IElasticClient>(client);

                CreateIndex(client,index);
               
            }
            catch (Exception ex)
            {
                
                demo.Error(ex.Message);
            }
                     

      
    }               

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var demo = LogMethod();
            try
            {
                var createIndexResponse = client.Indices.Create(indexName,
                                index => index.Map<EventModel>(x => x.AutoMap())
                            );
               
            }
            catch (Exception ex)
            {
                demo.Error(ex.Message);
            }
            
        }
    }
}
