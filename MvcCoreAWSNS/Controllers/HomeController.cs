using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSNS.Services;

namespace MvcCoreAWSNS.Controllers
{
    public class HomeController : Controller
    {
        private ServiceSNS ServiceSNS;
        public HomeController(ServiceSNS service)
        {
            this.ServiceSNS = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EnviarMensaje()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult EnviarMensaje(String mensaje, String asunto)
        {
            ViewData["RESPUESTA"] = this.ServiceSNS.SeedMessage(mensaje, asunto);
            return View();
        }
    }
}
