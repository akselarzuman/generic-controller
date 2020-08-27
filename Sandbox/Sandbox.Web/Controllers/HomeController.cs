using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GenericController.Framework;
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
        private readonly HtmlParser _parser;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGcRepository repo,
            HtmlParser parser,
            ILogger<HomeController> logger)
        {
            _repo = repo;
            _parser = parser;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string formScript = await _repo.RetrieveFormScriptAsync(1);
            List<FormInputList> formInputs = await _repo.RetrieveFormInputsAsync(1);
            var view = new View
            {
                Inputs = formInputs,
                Form = new FormEntity()
            };

            string html = new HtmlParser().GenerateForm(view);

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
