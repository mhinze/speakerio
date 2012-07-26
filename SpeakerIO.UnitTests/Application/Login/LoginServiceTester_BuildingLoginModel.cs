using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Should;
using SpeakerIO.Web.Application;
using SpeakerIO.Web.Application.Login;
using SpeakerIO.Web.Models;

namespace SpeakerIO.UnitTests.Application.Login
{
    [TestFixture]
    public class LoginServiceTester_BuildingLoginModel : TestBase
    {
        const string appname = "name";
        const string absoluteUrl = "foo";
        ILoginService login;
        LoginModel loginModel;

        [TestFixtureSetUp]
        public void When_building_a_login_model()
        {
            var settings = S<IApplicationSettings>();
            settings.Stub(x => x.JanrainAppName()).Return(appname);

            var url = S<IUrlResolver>();
            url.Stub(x => x.AbsoluteAction(Arg.Is("ProcessLogin"), Arg.Is("Account"), Arg<object>.Matches(Property.Value("returnUrl", "http://www.google.com"))))
                .Return(absoluteUrl);

            login = new LoginService(settings, url);
            loginModel = login.Build("http://www.google.com");
        }

        [Test]
        public void Should_set_process_url()
        {
            loginModel.ProcessAuthUrl.ShouldEqual(absoluteUrl);
        }

        [Test]
        public void Should_set_the_janrain_name()
        {
            loginModel.JanrainName.ShouldEqual(appname);
        }
    }
}