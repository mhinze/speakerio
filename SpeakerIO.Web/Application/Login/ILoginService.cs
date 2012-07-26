using System;
using SpeakerIO.Web.Models;

namespace SpeakerIO.Web.Application.Login
{
    public interface ILoginService
    {
        LoginModel Build(string returnUrl);
    }

    public class LoginService : ILoginService
    {
        readonly IApplicationSettings _settings;
        readonly IUrlResolver _url;

        public LoginService(IApplicationSettings settings, IUrlResolver url)
        {
            _settings = settings;
            _url = url;
        }

        public LoginModel Build(string returnUrl)
        {
            return new LoginModel
            {
                JanrainName = _settings.JanrainAppName(),
                ProcessAuthUrl = _url.AbsoluteAction("ProcessLogin", "Account", new {returnUrl})
            };
        }
    }
}