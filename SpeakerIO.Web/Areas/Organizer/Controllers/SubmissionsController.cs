using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Controllers;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    [Authorize]
    public class SubmissionsController : BaseController
    {
        public ActionResult Review(User user, long id)
        {
            using (var db = new DataContext(user))
            {
                var call = db.CallsForSpeakers.SingleOrDefault(c => c.Id == id && c.User.Id == user.Id);
                {
                    if (call == null)
                    {
                        Error("Invalid call for speakers");
                        return RedirectToAction("Index", "Home");
                    }
                    var submissions = db.Submissions.Where(x => x.CallForSpeakers.Id == id);
                    return View(submissions.ToArray());
                }
            }
        }
    }
}