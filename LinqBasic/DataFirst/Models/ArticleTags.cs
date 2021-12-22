using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataFirst.Models
{
    public partial class ArticleTags
    {
        public int ArticleTagId { get; set; }
        public int TagId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
