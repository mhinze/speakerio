using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Data;

namespace SpeakerIO.Web
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string userIdentifier = controllerContext.HttpContext.User.Identity.Name;
            using (var db = new DataContext())
            {
                return db.Users.SingleOrDefault(x => x.Identifier == userIdentifier);
            }
        }
    }
}