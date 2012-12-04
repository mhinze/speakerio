using System.Collections.Generic;
using System.Linq;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Models
{
    public class HomeViewModel
    {
        readonly CallForSpeakers[] _calls;
        readonly SpeakerProfile[] _speakers;

        public HomeViewModel(IEnumerable<CallForSpeakers> calls, IEnumerable<SpeakerProfile> speakers)
        {
            _calls = (calls ?? Enumerable.Empty<CallForSpeakers>()).ToArray();
            _speakers = (speakers ?? Enumerable.Empty<SpeakerProfile>()).ToArray();
        }

        public CallForSpeakers[] CallsForSpeakers
        {
            get { return _calls; }
        }

        public SpeakerProfile[] SpeakerProfiles
        {
            get { return _speakers;  }
        }

        public int CallForSpeakersCount
        {
            get { return _calls.Length; }
        }

        public int SpeakerProfileCount
        {
            get { return _speakers.Length; }
        }
    }
}