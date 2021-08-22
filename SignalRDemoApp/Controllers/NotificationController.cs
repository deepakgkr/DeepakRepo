using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemoApp.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _notificationHub;
        public NotificationController(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }

        [HttpPost("SendMessage")]
        public void SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message)) {
                _notificationHub.Clients.All.SendAsync("MESSAGE_FROM_SERVER", message);
            }
        }

    }
}
