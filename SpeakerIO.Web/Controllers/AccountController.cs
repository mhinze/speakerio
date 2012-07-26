using System.Web.Mvc;
using System.Web.Security;
using SpeakerIO.Web.Application.Login;

namespace SpeakerIO.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = _loginService.Build(returnUrl);

            return View(model);
        }

        [HttpPost]
        public ActionResult ProcessLogin(string token, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return Login(returnUrl);
            }

            var user = _loginService.ProcessLogin(token);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            FormsAuthentication.SetAuthCookie(user.Id, false);

            string url = Url.IsLocalUrl(returnUrl) ? returnUrl : "~/organizer/home";

            return Redirect(url);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}