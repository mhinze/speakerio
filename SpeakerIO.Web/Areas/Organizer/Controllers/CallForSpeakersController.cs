using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    [Authorize]
    public class CallForSpeakersController : Controller
    {
        [HttpGet]
        public ViewResult Create()
        {
            return View(new CallForSpeakersInput());
        }

        [HttpPost, ActionName("Create")]
        public ActionResult ProcessCreation(CallForSpeakersInput input, User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext())
                {
                    db.CallsForSpeakers.Add(new CallForSpeakers(input, user));
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}