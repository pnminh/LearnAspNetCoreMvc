using System.Text.RegularExpressions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LearnAspNetCoreMvc.Models
{
    public class Post
    {
        public long Id { get; set; }
        private string _key;
        public string Key
        {
            get
            {
                if (_key == null) _key = Regex.Replace(Title!=null?Title.ToLower():"-", "[^a-z0-9]", "-");
                return _key;
            }
            set { _key = Key; }
        }
        [Display(Name = "Post Title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        [MinLength(50,ErrorMessage="Blog post much be at least 50 characters long")]
        public string Body { get; set; }
        public DateTime Posted { get; set; }
    }
}