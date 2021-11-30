using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaDisal.Models
{
    [Table("LIST")]
    public partial class List
    {
        public List()
        {
            ProductoPrices = new HashSet<ProductoPrice>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(ProductoPrice.List))]
        public virtual ICollection<ProductoPrice> ProductoPrices { get; set; }
    }
}
