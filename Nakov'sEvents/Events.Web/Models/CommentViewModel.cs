using Events.Data;
using System;
using System.Linq.Expressions;

namespace Events.Web.Models
{
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Text = c.Text,
                    Author = c.Author.FullName
                };
            }
        }

        public string Author { get; set; }
        public string Text { get; set; }
    }
}