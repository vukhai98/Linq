using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Migratoin.Model
{
    [Table("Article")]
    public class Article
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { set; get; }

        [StringLength(100)]
        public string Name { set; get; }
        [Column(TypeName =  "ntext")]
        public string Content { set; get; }
    }
}
