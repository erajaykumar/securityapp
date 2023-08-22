using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Producer.Kafka.Controllers
{
    [Route("api/produce")]
    [ApiController]    
    public class ProducerController : ControllerBase
    {
        private readonly string server = "localhost:9092";
        private readonly string topic = "rule";

       

        [HttpPost]
        [Route("producemsg")]
        public async Task<ActionResult> Get([FromBody] Message message)
        {
            string serializedMessage = JsonConvert.SerializeObject(message);
          
                return Ok(await SendMessage(topic,serializedMessage));
            
        }
        private async Task<bool> SendMessage(string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = server,
                ClientId = Dns.GetHostName()
            };
            try
            {
                using(var producer=new ProducerBuilder<Null,string>(config).Build())
                {
                    var result = producer.ProduceAsync(topic, new Message<Null,string>
                    {
                        Value= message
                    });
                    producer.Flush();
                    return await Task.FromResult(true);
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await Task.FromResult(false);
        }


    }
}
