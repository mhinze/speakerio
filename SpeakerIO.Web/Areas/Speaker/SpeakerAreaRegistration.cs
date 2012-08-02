using System.Web.Mvc;

namespace SpeakerIO.Web.Areas.Speaker
{
    public class SpeakerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Speaker";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("speaker_submit", "speaker/submit/{slug}",
                             new { action = "Create", controller = "Submission" });

            context.MapRoute(
                "Speaker_default",
                "Speaker/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
