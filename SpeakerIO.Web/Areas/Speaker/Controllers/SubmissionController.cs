using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Areas.Speaker.Models;
using SpeakerIO.Web.Controllers;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Speaker.Controllers
{
    [Authorize]
    public class SubmissionController : BaseController
    {
        [HttpGet]
        public ActionResult Create(string slug)
        {
            using (var db = new DataContext())
            {
                var found = db.CallsForSpeakers.SingleOrDefault(x => x.Slug == slug);
                if (found == null)
                {
                    Error("Invalid call for speakers");
                    return RedirectToAction("Index", "Home");
                }
                return View(new SubmissionViewModel(found));
            }
        }

        [HttpPost, ActionName("Create")]
        public ActionResult ProcessSubmission(User user, SubmissionViewModel input)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
                {
                    var found = db.CallsForSpeakers.Find(input.CallForSpeakersId);
                    if (found == null)
                    {
                        Error("There was a problem submitting this session");
                        return RedirectToAction("Index", "Home", new {area = ""});
                    }
                    var submission = new Submission(user, input, found);
                    db.Submissions.Add(submission);
                    db.SaveChanges();
                }

                Success("Successfully submitted session");
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View("Create");
        }
    }
}