using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using playground_webapp.Models;

namespace playground_webapp.Controllers
{
    public class HomeController: Controller
    {
        IConfiguration configuration;
        public HomeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        
        public IActionResult Index()
        {
            ViewData["Message"] = configuration.GetValue<string>("AppSettings:Key1");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page." + Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
