using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Protocols;
using SpeakerIO.Web.Application.Login;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;
using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet, AllowAnonymous,]
        public ActionResult Login(string returnUrl)
        {
            var model = _loginService.Build(returnUrl);

            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public ActionResult ProcessLogin(string token, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return Login(returnUrl);
            }

            var status = _loginService.ProcessLogin(token);
            if (!status.SuccessfullyLoggedIn)
            {
                return RedirectToAction("Login");
            }

            FormsAuthentication.SetAuthCookie(status.UserIdentifier, true);

            var url = GetRedirectUrl(returnUrl, status);

            return Redirect(url);
        }

        string GetRedirectUrl(string returnUrl, LoginStatus status)
        {
            if (status.FirstLogin)
            {
                return Url.Action("Details");
            }
            return Url.IsLocalUrl(returnUrl) ? returnUrl : "~/organizer/home";
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Details(User user)
        {
            return View(new UserDetailsInput(user));
        }

        [HttpPost, ActionName("Details")]
        public ActionResult ProcessDetails(UserDetailsInput input, User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
                {
                    user.Name = input.Name;
                    user.Email = input.EmailAddress;
                    user.Twitter = input.Twitter;

                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home", new { area = "organizer" });
            }
            return View("Details");
        }

        [AllowAnonymous]
        public PartialViewResult Pbar(User user)
        {
            var model = new PbarModel
            {
                LoginLink = Url.Action("Login", new{returnUrl = HttpContext.Request.Url.AbsoluteUri}),
                LogoutLink = Url.Action("Logout"),
                AccountDetailsLink = Url.Action("Details")
            };

            if (user != null)
            {
                model.IsAuthenticated = true;
                model.UsersName = user.Name;
                model.PictureUrl = user.ImageUrl;    
            }

            return PartialView(model);
        }
    }

    public class PbarModel
    {
        public bool IsAuthenticated { get; set; }
        public string PictureUrl { get; set; }
        public string UsersName { get; set; }
        public string AccountDetailsLink { get; set; }
        public string LogoutLink { get; set; }
        public string LoginLink { get; set; }
    }
}