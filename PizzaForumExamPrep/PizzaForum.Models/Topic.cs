
namespace PizzaForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Topic
    {
        public Topic()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}