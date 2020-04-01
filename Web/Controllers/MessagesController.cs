using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/web/messages")]
    public class MessagesController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public MessagesController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }


    }
}