using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Api
{
    public class EventPlanController : ApiController
    {
        public EventPlanningModel Get(int id)
        {
            var result = new EventPlanningModel();

            using (var db = new DataContext())
            {
                var conf = db.CallsForSpeakers.Include(x => x.Organizer)
                    .SingleOrDefault(x => x.Id == id);

                if (conf == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }

                result.EventName = conf.EventName;
                result.EventDescription = conf.Description;
                result.EventLogoUrl = conf.LogoUrl;

                result.OrganizerName = conf.Organizer.Name;
                result.OrganizerEmail = conf.Organizer.Email;

                result.FirstDay = conf.FirstDayOfEvent;
                result.LastDay = conf.LastDayOfEvent;
                result.LastDayToSubmit = conf.LastDayToSubmit;

                var acceptedSessions = db.Submissions.Include(x => x.Speaker)
                    .Where(s => s.CallForSpeakers.Id == id && s.Status == Submission.Accepted).ToArray();

                result.AcceptedSubmissions = acceptedSessions.Select(x => new AcceptedSubmissions
                {
                    Abstract = x.Abstract,
                    Title = x.Title,
                    SpeakerEmail = x.Speaker.Email,
                    SpeakerName = x.Speaker.Name,
                    SpeakerPhotoUrl = x.Speaker.ImageUrl,
                    SpeakerTwitter = x.Speaker.Twitter,
                });
            }

            return result;
        }
    }

    public class EventPlanningModel
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLogoUrl { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerEmail { get; set; }
        public DateTime? FirstDay { get; set; }
        public DateTime? LastDay { get; set; }
        public DateTime? LastDayToSubmit { get; set; }

        public IEnumerable<AcceptedSubmissions> AcceptedSubmissions { get; set; }
    }

    public class AcceptedSubmissions
    {
        public string SpeakerName { get; set; }
        public string SpeakerEmail { get; set; }
        public string SpeakerPhotoUrl { get; set; }
        public string SpeakerTwitter { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
    }
}