using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SendListMicroservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : ControllerBase
    {
  
        private readonly IBus _busService;
        public SendController(IBus busService)
        {
            _busService = busService;
            Task.Run(()=> SendList());
        }
        //Task to send thd list to the Queue Manager and get status if send or not
        public async Task<string> SendList()
        {
            //Create a random age
            var rngAge = new Random();

            //Create a list of objects and insert them to the list
            var p = new Person(DateTime.Now, "Shuki Cohen", rngAge.Next(10,20), "Football Player");
            var p2 = new Person(DateTime.Now, "Dani Cohen", rngAge.Next(20,30), "BasketBall Player");
            var p3 = new Person(DateTime.Now, "Shlomi Cohen", rngAge.Next(30,40), "Barber");
            Person[] peopleArr = { p, p2, p3 };

            if (peopleArr != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/MassTransitQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(peopleArr);
                return "Sent successefully";
            }
            return "Error,Not send";
        }
    }
}
