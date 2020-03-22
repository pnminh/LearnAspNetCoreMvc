using System;

namespace LearnAspNetCoreMvc.Services
{
    public interface IFormatService
    {
        public string ToReadableDate(DateTime date);
    }
}