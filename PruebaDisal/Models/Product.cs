using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaDisal.Models
{
    [Table("PRODUCT")]
    public partial class Product
    {
        public Product()
        {
            ProductTaxes = new HashSet<ProductTax>();
            ProductoPrices = new HashSet<ProductoPrice>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("STATE")]
        public bool State { get; set; }

        [InverseProperty(nameof(ProductTax.Product))]
        public virtual ICollection<ProductTax> ProductTaxes { get; set; }
        [InverseProperty(nameof(ProductoPrice.Product))]
        public virtual ICollection<ProductoPrice> ProductoPrices { get; set; }
    }
}
