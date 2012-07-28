using System;

namespace SpeakerIO.Web.Application.Extensions
{
    public static class DateFormatExtensions
    {
         public static string ToDate(this DateTime? date)
         {
             if (date == null)
                 return string.Empty;
             return date.Value.ToShortDateString();
         }
    }
}