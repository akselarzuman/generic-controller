using Microsoft.AspNetCore.Mvc;
using GenericController.Repository;
using GenericController.Framework;

namespace GenericController.Controllers
{
    public class HomeController : Controller
    {
        private IGcRepository _repo;
        public HomeController(IGcRepository repo)
        {
            this._repo = repo;
        }


        public IActionResult Index()
        {

            var form = _repo.RetrieveForm(1);

            var formInputs = _repo.RetrieveFormInputs(1);
            
            string html = new HtmlParser().GenerateForm(formInputs);

            return View("Index",html);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
