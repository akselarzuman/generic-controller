using Microsoft.AspNetCore.Mvc;
using GenericController.DataAccess;

namespace GenericController.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        public HomeController(IRepository repo)
        {
            this._repo = repo;
        }


        public IActionResult Index()
        {

            var form = _repo.RetrieveForm(1);

            var formInputs = _repo.RetrieveFormInputs(1);
            
            string html = new HtmlParser().GenerateForm(new { Inputs = formInputs });

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
