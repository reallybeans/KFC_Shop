using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KFC_Food.Models
{
    [Table("tblProducts")]
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }
        
        [Key]
        [Column("productID")]
        [StringLength(50)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }
        [Required]
        [Column("productName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Required]
        [Column("description")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Required]
        [Column("img_src")]
        [StringLength(3000)]
        public string ImgSrc { get; set; }
        [Required]
        [Column("categoryID")]
        [StringLength(50)]
        public string CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(TblCategory.TblProducts))]
        public virtual TblCategory Category { get; set; }
        [InverseProperty(nameof(TblOrderDetail.Product))]
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
