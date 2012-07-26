using JetBrains.Annotations;

namespace SpeakerIO.Web.Application
{
    public interface IUrlResolver
    {
        string AbsoluteAction([AspMvcAction] string action,
                              [AspMvcController] string controller,
                              object routeValues);

        bool IsLocalUrl(string url);
    }
}