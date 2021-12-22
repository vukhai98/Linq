using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF2
{
    [Table("Categories")]
   public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Discription { get; set;  }
        // Collect Navigation 
        public List<Product> Products { get; set; }  
        public CategoryDetails CategoryDetails { get; set; }
       
    }
}
