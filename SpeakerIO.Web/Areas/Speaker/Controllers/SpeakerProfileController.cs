using System.Web.Mvc;
using System.Web.Routing;
using SpeakerIO.Web.Areas.Speaker.Models;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Speaker.Controllers
{
    public class SpeakerProfileController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CreateSpeakerProfileInput());
        }

        [HttpPost, ActionName("Create")]
        public ActionResult ProcessCreation(CreateSpeakerProfileInput input, User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
                {
                    db.SpeakerProfiles.Add(new SpeakerProfile(input, user));
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home", new {area = "Organizer"});
            }
            return View();
        }
    }
}