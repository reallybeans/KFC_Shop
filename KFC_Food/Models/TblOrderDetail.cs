using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KFC_Food.Models
{
    [Table("tblOrderDetails")]
    public partial class TblOrderDetail
    {
        [Key]
        [Column("detailID")]
        public int DetailId { get; set; }
        [Required]
        [Column("orderID")]
        [StringLength(50)]
        public string OrderId { get; set; }
        [Required]
        [Column("productID")]
        [StringLength(50)]
        public string ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price")]
        public double Price { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(TblOrder.TblOrderDetails))]
        public virtual TblOrder Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(TblProduct.TblOrderDetails))]
        public virtual TblProduct Product { get; set; }
    }
}
