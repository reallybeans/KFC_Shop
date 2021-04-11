using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KFC_Food.Models
{
    [Table("tblRoles")]
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        [Column("roleID")]
        [StringLength(50)]
        public string RoleId { get; set; }
        [Required]
        [Column("roleName")]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(TblUser.Role))]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
