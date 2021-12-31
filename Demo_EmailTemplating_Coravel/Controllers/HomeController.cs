using Coravel.Mailer.Mail.Interfaces;
using Demo_EmailTemplating_Coravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_EmailTemplating_Coravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailer _mailer;

        public HomeController(ILogger<HomeController> logger, IMailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> RenderCareerReportView()
        {
            //Message contiene el text html que se enviara por correo, ya con esto se pondria como cuerpo del correo o se guardaria el archvio de texto
            string message = await this._mailer.RenderAsync(new CareerReportViewMailable(GetStudent()));
            return Content(message, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Student GetStudent()
        {
            return new Student()
            {
                Career = "Ingenieria de Sistemas de Información",
                Cycles = new List<Cycle>()
                {
                    new Cycle()
                    {
                        Period = "2021-01",
                        Grade = 18.25f
                    },
                    new Cycle()
                    {
                        Period = "2021-02",
                        Grade = 18.5f
                    }
                },
                Firstname = "Arthur",
                Lastname = "Valladares",
                StudentCode = "U20156AAA"
            };
        }
    }
}
