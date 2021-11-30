using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaDisal.Models
{
    [Table("PRODUCT_TAX")]
    public partial class ProductTax
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("PRODUCT_ID")]
        public long ProductId { get; set; }
        [Column("TAX_ID")]
        public long TaxId { get; set; }
        [Required]
        [Column("TYPE")]
        [StringLength(10)]
        public string Type { get; set; }
        [Column("VALUE", TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        [Column("STATE")]
        public bool State { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductTaxes")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(TaxId))]
        [InverseProperty("ProductTaxes")]
        public virtual Tax Tax { get; set; }
    }
}
