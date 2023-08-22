using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Kafka.Producer.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ProducerConfig _producerConfig;

        public ProducerController(ProducerConfig producerConfig)
        {
            _producerConfig = producerConfig;
        }

        [HttpPost("send")]
        public async Task<ActionResult> Get(string topic, [FromBody] Message message)
        {
            string serializedMessage = JsonConvert.SerializeObject(message);
            using (var producer = new ProducerBuilder<Null, string>(_producerConfig).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedMessage });
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok(true);
            }
        }
        public IActionResult Index()
        {
            return null;
            //return View();
        }
       
    }
}
