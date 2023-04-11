using BeesApplication.Models;
using BeesApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeesApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  BeeDataService beeDataService;

        public HomeController(ILogger<HomeController> logger,BeeDataService beeDataService)
        {
            _logger = logger;
            this.beeDataService = beeDataService;

        }
        [HttpGet]
        [Route("/index")]
        [Route("/")]
        public IActionResult Index()
        {
        
            List<BeeViewModel> beesVM = (from s in this.beeDataService.getBees()
                                         select new BeeViewModel
                                         {
                                            type=s.Type,
                                            health=s.Health,
                                            dead=s.Dead,
                                            imageURL=s.ImageURL,
                                            reference=s.reference

                                         }).ToList();

           
            return View(beesVM);
        }

        [HttpGet]
        [Route("/damage")]
        public string damage()
        {
            
            foreach(var i in this.beeDataService.getBees())
            {
                var damage = new Random().Next(81);
                i.Damage(damage);
            }
            return JsonConvert.SerializeObject(this.beeDataService.getBees());

        }

        [HttpGet]
        [Route("/restart")]
        public IActionResult restart()
        {
            this.beeDataService.restart();
           return RedirectToAction("Index");
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
