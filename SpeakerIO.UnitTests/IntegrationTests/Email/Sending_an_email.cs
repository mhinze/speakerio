﻿using System.ComponentModel;
using NUnit.Framework;
using SpeakerIO.Web.Application.Email;

namespace SpeakerIO.UnitTests.IntegrationTests.Email
{
    [TestFixture]
    public class Sending_an_email
    {
        [Test, Explicit]
        public void Test_email()
        {
            var email = new EmailMessage()
            {
                To = new[] { "test34@mailinator.com" },
                From = "test@speakerio-test.mailgun.com",
                Text = "this is a test"
            };

            var emailService = new EmailService();
            emailService.Send(email);
        }    
    }
}