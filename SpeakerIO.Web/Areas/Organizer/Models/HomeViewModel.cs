using System.Collections.Generic;
using System.Linq;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Models
{
    public class HomeViewModel
    {
        readonly CallForSpeakers[] _calls;

        public HomeViewModel(IEnumerable<CallForSpeakers> calls)
        {
            _calls = (calls ?? Enumerable.Empty<CallForSpeakers>()).ToArray();
        }

        public CallForSpeakers[] CallsForSpeakers
        {
            get { return _calls.ToArray(); }
        }

        public int CallForSpeakersCount
        {
            get { return _calls.Length; }
        }
    }
}