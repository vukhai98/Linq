using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataFirst.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int ArticleId { get; set; }
        public string ArticleName { get; set; }

        public string ArticleContent { get; set; }


        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
