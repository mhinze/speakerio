using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var model = new HomeViewModel();
            using (var db = new DataContext())
            {
                model.CallForSpeakersCount = db.CallsForSpeakers.Count();
                return View(model);
            }
        }
    }
}