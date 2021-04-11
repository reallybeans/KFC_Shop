using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KFC_Food.Models
{
    [Table("tblOrders")]
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        [Key]
        [Column("orderID")]
        [StringLength(50)]
        public string OrderId { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("address")]
        [StringLength(300)]
        public string Address { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [Column("paymentType")]
        [StringLength(50)]
        public string PaymentType { get; set; }
        [Column("totalPrice")]
        public double TotalPrice { get; set; }
        [Column("time", TypeName = "smalldatetime")]
        public DateTime Time { get; set; }

        [ForeignKey(nameof(UserName))]
        [InverseProperty(nameof(TblUser.TblOrders))]
        public virtual TblUser UserNameNavigation { get; set; }
        [InverseProperty(nameof(TblOrderDetail.Order))]
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
