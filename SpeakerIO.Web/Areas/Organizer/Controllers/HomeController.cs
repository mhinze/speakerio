using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index(User user)
        {
            var model = new HomeViewModel();
            using (var db = new DataContext(user))
            {
                model.CallForSpeakersCount = db.CallsForSpeakers.Count(x => x.User.Id == user.Id);
                return View(model);
            }
        }
    }
}