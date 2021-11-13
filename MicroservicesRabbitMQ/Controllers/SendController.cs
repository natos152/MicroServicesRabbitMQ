using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesRabbitMQ.Controllers
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
        }

        [HttpPost]
        public async Task<List<Person>> SendList()
        {
            var rngAge = new Random();
            List<Person> peopleList = new List<Person>();
            peopleList.Add(new Person(DateTime.Now, "test", rngAge.Next(18, 30), "prof"));
            peopleList.Add(new Person(DateTime.Now, "test2", rngAge.Next(31, 60), "prof2"));
            peopleList.Add(new Person(DateTime.Now, "test3", rngAge.Next(61, 90), "prof2"));
            if (peopleList != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/personListQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(peopleList);
                return peopleList;
            }
            return null;
        }
    }
}
