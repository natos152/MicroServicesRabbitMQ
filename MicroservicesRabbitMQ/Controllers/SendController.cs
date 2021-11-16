using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendListMicroservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {
        //private readonly ILogger<SendController> _logger;

        //public SendController(ILogger<SendController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<Person> Get()
        //{
        //    var rngAge = new Random();
        //    List<Person> people = new List<Person>();
        //    people.Add(new Person(DateTime.Now, "test", rngAge.Next(18, 30), "prof"));
        //    people.Add(new Person(DateTime.Now, "test2", rngAge.Next(31, 60), "prof2"));
        //    people.Add(new Person(DateTime.Now, "test3", rngAge.Next(61, 90), "prof2"));

        //    return people;

        //}

        private readonly IBus _busService;
        public SendController(IBus busService)
        {
            _busService = busService;
            SendList();
        }

        public async Task<string> SendList()
        {
            var rngAge = new Random();
            var p = new Person(DateTime.Now, "Shuki Cohen", rngAge.Next(10,20), "Barber");
            var p2 = new Person(DateTime.Now, "Dani Cohen", rngAge.Next(20,30), "Barber");
            var p3 = new Person(DateTime.Now, "Shlomi Cohen", rngAge.Next(30,40), "Barber");
            Person[] peopleArr =  { p, p2, p3 };
            //string sJSONResponse = JsonConvert.SerializeObject(list);
            if (peopleArr != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/newQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(peopleArr);
                return "Sent successefully";
            }
            return "Error,Not send";
        }
    }
}
