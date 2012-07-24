using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    public class CallForSpeakerController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CallForSpeakerInput());
        }

        [HttpPost, ActionName("Create")]
        public ActionResult PostCreation(CallForSpeakerInput input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}