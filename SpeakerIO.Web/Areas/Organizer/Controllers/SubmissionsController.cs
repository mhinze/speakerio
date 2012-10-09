using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SpeakerIO.Web.Application.Email;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Controllers;
using SpeakerIO.Web.Data;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Controllers
{
    [Authorize]
    public class SubmissionsController : BaseController
    {
        readonly IDomainEmailSender _email;

        public SubmissionsController(IDomainEmailSender email)
        {
            _email = email;
        }

        [HttpGet]
        public ActionResult Review(User user, long id)
        {
            return RenderReview(user, id);
        }

        ActionResult RenderReview(User user, long id)
        {
            using (var db = new DataContext(user))
            {
                var submissions = db.Submissions.Include(x => x.CallForSpeakers)
                    .Include(x => x.Speaker)
                    .Where(x => x.CallForSpeakers.Id == id &&
                        x.CallForSpeakers.User.Id == user.Id);

                if (!submissions.Any())
                {
                    Error("No submissions");
                    return RedirectToAction("Index", "Home");
                }

                return View("Review", submissions.ToArray());
            }
        }

        [HttpPost]
        public ActionResult Reject(User user, RejectionInput input)
        {
            return PerformTransition(user, input, x => x.Reject(input.Reason, _email), "You have successfully rejected this submission");
        }

        ActionResult PerformTransition(User user, DecisionInput input, Action<Submission> action, string successText)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataContext(user))
                {
                    var submission = db.Submissions.Include(x => x.CallForSpeakers)
                        .SingleOrDefault(x => x.Id == input.Id &&
                            x.CallForSpeakers.Id == input.CallForSpeakersId &&
                            x.CallForSpeakers.User.Id == user.Id);

                    if (submission != null)
                    {
                        action(submission);
                        db.SaveChanges();
                        Success(successText);
                    }
                    else
                    {
                        Error("Invalid submission");
                    }
                    return RedirectToAction("Review", new { id = input.CallForSpeakersId });
                }
            }
            return RenderReview(user, input.CallForSpeakersId);
        }

        [HttpPost]
        public ActionResult Accept(User user, DecisionInput input)
        {
            return PerformTransition(user, input, x => x.Accept(_email), "You have successfully accepted this submission.");
        }
    }
}