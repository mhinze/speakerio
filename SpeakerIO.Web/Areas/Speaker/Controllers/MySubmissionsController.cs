using System.Web.Mvc;
using SpeakerIO.Web.Controllers;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;
using System.Linq;

namespace SpeakerIO.Web.Areas.Speaker.Controllers
{
    public class MySubmissionsController : BaseController
    {
        public ViewResult Index(User speaker)
        {
            using (var db = new DataContext(speaker))
            {
                var all = db.Submissions
                    .Include("CallForSpeakers")
                    .AsNoTracking()
                    .Where(x => x.Speaker.Id == speaker.Id)
                    .OrderBy(x => x.CallForSpeakers.LastDayToSubmit)
                    .ThenBy(x => x.CallForSpeakers.EventName)
                    .ThenBy(x => x.Title)
                    .ToArray();

                return View("Index", all);
            }
        }

        public ActionResult Submission(User speaker, long id)
        {
            using (var db = new DataContext(speaker))
            {
                var sub = db.Submissions.Include("CallForSpeakers").SingleOrDefault(x => x.Id == id && x.Speaker.Id == speaker.Id);
                if (sub == null)
                {
                    Error("Invalid submission");
                    return RedirectToAction("Index", "MySubmissions");
                }
                return View(sub);
            }
        }
    }
}