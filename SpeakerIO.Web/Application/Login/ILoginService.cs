using SpeakerIO.Web.Data.Model;
using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Application.Login
{
    public interface ILoginService
    {
        LoginModel Build(string returnUrl);
        User ProcessLogin(string token);
    }
}