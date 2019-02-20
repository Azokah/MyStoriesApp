using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMyStories.Controllers
{
    public class MyFirstController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }


        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["numTimes"] = numTimes;
            return View();
        }
    }
}
