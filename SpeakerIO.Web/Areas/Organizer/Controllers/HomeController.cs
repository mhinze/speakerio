using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    public class HomeController : Controller
    {
         public ViewResult Index()
         {
             return View(new HomeViewModel());
         }
    }
}