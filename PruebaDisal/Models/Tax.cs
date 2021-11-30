using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaDisal.Models
{
    [Table("TAX")]
    public partial class Tax
    {
        public Tax()
        {
            ProductTaxes = new HashSet<ProductTax>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("STATE")]
        public bool? State { get; set; }

        [InverseProperty(nameof(ProductTax.Tax))]
        public virtual ICollection<ProductTax> ProductTaxes { get; set; }
    }
}
