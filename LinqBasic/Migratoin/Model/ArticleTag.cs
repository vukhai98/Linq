using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Migratoin.Model
{
    public class ArticleTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleTagId { get; set; }
        public int TagId { get; set; } // Fk
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int ArticleId { get; set; } //Fk
    }
}
