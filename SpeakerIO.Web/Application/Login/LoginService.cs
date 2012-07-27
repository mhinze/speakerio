using System.Linq;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;
using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Application.Login
{
    public class LoginService : ILoginService
    {
        readonly IJanrainEngageClient _engageClient;
        readonly IApplicationSettings _settings;
        readonly IUrlResolver _url;

        public LoginService(IApplicationSettings settings,
                            IUrlResolver url,
                            IJanrainEngageClient engageClient)
        {
            _settings = settings;
            _url = url;
            _engageClient = engageClient;
        }

        public LoginModel Build(string returnUrl)
        {
            return new LoginModel
            {
                JanrainName = _settings.JanrainAppName(),
                ProcessAuthUrl = _url.AbsoluteAction("ProcessLogin", "Account", new { returnUrl })
            };
        }

        public LoginStatus ProcessLogin(string token)
        {
            var authInfo = _engageClient.GetAuthInfo(token);

            if (authInfo == null || !authInfo.IsOk())
                return LoginStatus.Failed();

            var identifier = authInfo.profile.identifier;

            using (var db = new DataContext())
            {
                User foundUser = db.Users.SingleOrDefault(x => identifier == x.Identifier);
                if (foundUser != null)
                {
                    return LoginStatus.ReturnVisit(identifier);
                }
                var newUser = new User(identifier)
                {
                    Email = authInfo.profile.verifiedEmail ?? authInfo.profile.email,
                    Name = authInfo.profile.displayName,
                    ImageUrl = authInfo.profile.photo
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                return LoginStatus.FirstVisit(identifier);
            }
        }
    }
}