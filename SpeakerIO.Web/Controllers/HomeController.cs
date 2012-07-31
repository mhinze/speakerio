using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Data;

namespace SpeakerIO.Web.Controllers
{
    public class HomeController : Controller
    {
         public ViewResult Index()
         {
             return View();
         }

        public ActionResult Call(string key)
        {
            using (var db = new DataContext())
            {
                var found = db.CallsForSpeakers.AsNoTracking().SingleOrDefault(x => x.Slug.ToLower() == key.ToLower());
                if (found == null)
                {
                    TempData["error"] = "The call for speakers cannot be found";
                    return RedirectToAction("Index");
                }
                return View(found);
            }
        }
    }
}