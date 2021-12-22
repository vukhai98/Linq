using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Migratoin.Model
{
    public class Tag
    {
        //[Key]
        //[StringLength(20)]
        //public string TagId { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}
