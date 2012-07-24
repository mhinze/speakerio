using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    public class CallForSpeakersController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CallForSpeakersInput());
        }

        [HttpPost, ActionName("Create")]
        public ActionResult PostCreation(CallForSpeakersInput input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}