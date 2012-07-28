using System.Web.Mvc;

namespace SpeakerIO.Web.Controllers
{
    public class HomeController : Controller
    {
         public ViewResult Index()
         {
             return View();
         }
    }
}