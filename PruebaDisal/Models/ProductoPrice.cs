using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaDisal.Models
{
    [Table("PRODUCTO_PRICE")]
    public partial class ProductoPrice
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("PRODUCT_ID")]
        public long ProductId { get; set; }
        [Column("LIST_ID")]
        public long ListId { get; set; }
        [Column("DATE_INIT", TypeName = "date")]
        public DateTime DateInit { get; set; }
        [Column("DATE_END", TypeName = "date")]
        public DateTime DateEnd { get; set; }
        [Column("VALUE", TypeName = "money")]
        public decimal Value { get; set; }
        [Column("STATE")]
        public bool State { get; set; }

        [ForeignKey(nameof(ListId))]
        [InverseProperty("ProductoPrices")]
        public virtual List List { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductoPrices")]
        public virtual Product Product { get; set; }
    }
}
