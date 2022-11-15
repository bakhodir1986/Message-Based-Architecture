using MessagingClient;
using Microsoft.AspNetCore.Mvc;

namespace Basket_Service.Controllers
{
    public class BasketController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return Receive.ReceiveMessage();
        }
    }
}
