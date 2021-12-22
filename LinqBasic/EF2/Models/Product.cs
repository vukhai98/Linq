using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF2
{
    //[Table("Product")]
    public class Product
    {
        //[Key] = HasKey(p => p.ProductId);
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        //[Required]
        //[StringLength(50)]
        //[Column("TenSanPham",TypeName ="ntext")] 
        public string Name { get; set; }
        public decimal Price { get; set; }
        //Reference Navigation
        //ForeignKey
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; } //FK -> PK
        public virtual int? CategoryId { get;  set; }

        //[ForeignKey("CategoryId2")]
        //[InverseProperty("Products")]
        public Category Category2 { get; set; } //FK -> PK
        public virtual int? CategoryId2 { get; set; }


        public void PrinInfo()
        {
            Console.WriteLine($"{ProductId} - {Name} - {Price} - {CategoryId}");
        }
    }
    /*
     * Table("TableName")
     * [Key] -> Primary Key [PK]
     * [Required] -> not null
     * [StringLength(50)]-> string - navarchar
     * Column("Tensanpham",TypeName= "ntext")]
     * Reference Navigation -> Foreign key (1- nhiều)
     * Collection Navigation -> (không tạo ra Fk)
     * InverseProperty
     */
}
