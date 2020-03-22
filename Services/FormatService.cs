using System;

namespace LearnAspNetCoreMvc.Services
{
    public class FormatService : IFormatService
    {
        public string ToReadableDate(DateTime date)
        {
            return date.ToString("D");
        }
    }
}