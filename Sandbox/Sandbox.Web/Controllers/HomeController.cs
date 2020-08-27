using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GenericController.Framework.Contracts;
using GenericController.Repository.Contracts;
using GenericController.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Web.Models;

namespace Sandbox.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGcRepository _repo;
        private readonly IHtmlGenerator _generator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGcRepository repo,
            IHtmlGenerator generator,
            ILogger<HomeController> logger)
        {
            _repo = repo;
            _generator = generator;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string formScript = _repo.RetrieveFormScriptAsync(1).Result;
            List<FormInputList> formInputs = _repo.RetrieveFormInputsAsync(1).Result;
            var view = new View
            {
                Inputs = formInputs,
                Form = new FormEntity()
            };

            string html = _generator.GenerateForm(view);

            return View("Index", html);
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
