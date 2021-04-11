using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KFC_Food.Models
{
    [Table("tblCategories")]
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        [Key]
        [Column("categoryID")]
        [StringLength(50)]
        public string CategoryId { get; set; }
        [Required]
        [Column("categoryName")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(TblProduct.Category))]
        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
