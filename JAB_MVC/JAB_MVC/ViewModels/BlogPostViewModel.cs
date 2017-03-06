using JAB.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace JAB_MVC.ViewModels
{
    public class BlogPostViewModel 
    {
        public BlogPostViewModel() { }

        public BlogPostViewModel(BlogPost blogPost)
        {
            Id = blogPost.Id;
            PostTitle = blogPost.PostTitle;
            PostBody = blogPost.PostBody;
            Date = blogPost.Date;
            Publish = blogPost.Publish;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Post title is required.")]
        [MaxLength(128)]
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }

        [Required(ErrorMessage = "Post body is required.")]
        [Display(Name = "Post Body")]
        [MaxLength(5000)]
        public string PostBody { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Publish Post")]
        public bool Publish { get; set; }

    }
}