using System.Web.Mvc;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;
using System.Linq;

namespace SpeakerIO.Web.Areas.Speaker.Controllers
{
    public class MySubmissionsController : Controller
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

                return View(all);
            }
        }
    }
}