using System.Web.Mvc;
using RestSharp.Contrib;
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
            return View("Create", new CallForSpeakersInput());
        }

        [HttpGet]
        public ActionResult Edit(User user, long id)
        {
            using (var db = new DataContext(user))
            {
                var found = db.CallsForSpeakers.Find(id);
                if (found == null || found.User.Id != user.Id)
                {
                    return InvalidEdit();
                }
                return View("Create", new CallForSpeakersInput(found));
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult ProcessEdit(CallForSpeakersInput input, User user)
        {
            if (input.Id == null)
            {
                return InvalidEdit();
            }
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
                {
                    var found = db.CallsForSpeakers.Find(input.Id);
                    if (found.User.Id != user.Id)
                    {
                        return InvalidEdit();
                    }
                    found.UpdateFrom(input);
                    db.SaveChanges();

                    TempData["success"] = "You edited call for speaker for " + found.EventName; // encoded in view
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Create");
        }

        ActionResult InvalidEdit()
        {
            TempData["error"] = "Invalid edit";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Create")]
        public ActionResult ProcessCreation(CallForSpeakersInput input, User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
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