using System.Web.Mvc;
using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(LoginModel input)
        {
            return View(input);
        }
    }
}