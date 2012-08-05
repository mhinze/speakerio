using System.Collections.Generic;
using System.Linq;

namespace SpeakerIO.Web.Application.Email
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            To = Enumerable.Empty<string>();
            Cc = Enumerable.Empty<string>();
            Bcc = Enumerable.Empty<string>();
        }

        public IEnumerable<string> To { get; set; }
        public IEnumerable<string> Cc { get; set; }
        public IEnumerable<string> Bcc { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
}