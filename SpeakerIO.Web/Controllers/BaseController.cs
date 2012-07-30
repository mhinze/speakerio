using System.Web.Mvc;

namespace SpeakerIO.Web.Controllers
{
    public class BaseController : Controller
    {
        protected void Error(string error)
        {
            TempData["error"] = error;
        }

        protected void Success(string success)
        {
            TempData["success"] = success;
        }

        protected void Info(string info)
        {
            TempData["info"] = info;
        }

        protected void Attention(string attention)
        {
            TempData["attention"] = attention;
        }
    }
}