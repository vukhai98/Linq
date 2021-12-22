using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataFirst.Models
{
    public partial class Tags
    {
        public Tags()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public string Content { get; set; }
        public int TagId { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
