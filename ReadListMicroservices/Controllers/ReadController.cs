using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Models;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroservicesRabbitMQ.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        //private readonly ILogger<ReadController> _logger;

        //public ReadController(ILogger<ReadController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<Person> Get()
        //{
        //    //var rngAge = new Random();
        //    //List<Person> people = new List<Person>();
        //    //people.Add(new Person(DateTime.Now, "test", rngAge.Next(18, 30), "prof"));
        //    //people.Add(new Person(DateTime.Now, "test2", rngAge.Next(31, 60), "prof2"));
        //    //people.Add(new Person(DateTime.Now, "test3", rngAge.Next(61, 90), "prof2"));
        //    return /*people*/;

        //}
    }
}
