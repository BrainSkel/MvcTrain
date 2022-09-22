using Microsoft.AspNetCore.Mvc;

namespace MvcTrains.Controllers
{
    public class TrainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is a welcome ction metod";
        }
    }
}
