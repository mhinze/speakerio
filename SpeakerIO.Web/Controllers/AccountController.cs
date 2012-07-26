using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using RestSharp;
using SpeakerIO.Web.Application;
using SpeakerIO.Web.Application.Login;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;
using SpeakerIO.Web.Models;

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
            try
            {
                var client = new RestClient("https://rpxnow.com/");
                var request = new RestRequest("api/v2/auth_info");
                request.AddParameter("token", token);
                request.AddParameter("apiKey", ConfigurationManager.AppSettings["janrainApiKey"]);

                // ಠ_ಠ
                // client.Proxy = new System.Net.WebProxy("127.0.0.1", 5865);
                // client.Proxy = new System.Net.WebProxy("10.210.54.120", 5865);
                client.Proxy = new System.Net.WebProxy(new System.Uri("http://proxy:80"), false, null, System.Net.CredentialCache.DefaultNetworkCredentials);

                IRestResponse<AuthInfo> response = client.Execute<AuthInfo>(request);

                if (response != null &&
                    response.Data != null &&
                    response.Data.IsOk() &&
                    response.Data.profile != null)
                {
                    using (var db = new DataContext())
                    {
                        User foundUser = db.Users.Find(response.Data.profile.identifier);
                        if (foundUser == null)
                        {
                            var newUser = new User(response.Data.profile.identifier)
                            {
                                Email = response.Data.profile.verifiedEmail ?? response.Data.profile.email,
                                Name = response.Data.profile.displayName,
                                ImageUrl = response.Data.profile.photo
                            };
                            db.Users.Add(newUser);
                            db.SaveChanges();
                        }
                    }
                    FormsAuthentication.SetAuthCookie(response.Data.profile.identifier, false);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                return RedirectToAction("Login");
            }

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