﻿using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index(User user)
        {
            using (var db = new DataContext(user))
            {
                var calls = db.CallsForSpeakers.AsNoTracking().Where(x => x.Organizer.Id == user.Id);
                var speakers = db.SpeakerProfiles.AsNoTracking().Where(x => x.Maintainer.Id == user.Id);

                var model = new HomeViewModel(calls, speakers);

                return View(model);
            }
        }
    }
}