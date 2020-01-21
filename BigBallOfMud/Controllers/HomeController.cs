using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBallOfMud.Lib;

namespace BigBallOfMud
{
    public class HomeController : Controller
    {
        private readonly IGreetingProvider _provider;

        public HomeController(IGreetingProvider provider)
        {
            _provider = provider;
        }

        [Route("/")]
        [HttpGet]
        public string Index() => _provider.GetGreeting();
    }
}
