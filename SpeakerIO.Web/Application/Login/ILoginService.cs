using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Application.Login
{
    public interface ILoginService
    {
        LoginModel Build(string returnUrl);
        LoginStatus ProcessLogin(string token);
    }

    public class LoginStatus
    {
        LoginStatus() {}

        LoginStatus(string identifier)
        {
            UserIdentifier = identifier;
            SuccessfullyLoggedIn = true;
        }

        public bool SuccessfullyLoggedIn { get; private set; }
        public string UserIdentifier { get; private set; }
        public bool FirstLogin { get; private set; }

        public static LoginStatus Failed()
        {
            return new LoginStatus();
        }

        public static LoginStatus ReturnVisit(string identifier)
        {
            return new LoginStatus(identifier);
        }

        public static LoginStatus FirstVisit(string identifier)
        {
            return new LoginStatus(identifier) { FirstLogin = true };
        }
    }
}