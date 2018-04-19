
namespace PizzaForum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
    }
}