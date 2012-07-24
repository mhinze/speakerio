using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    public class CallForSpeakerController : Controller
    {
        public ViewResult Create()
        {
            return View(new CallForSpeakerViewModel());
        }
    }
}