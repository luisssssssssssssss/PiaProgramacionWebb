using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        [Column("Id_ususario")]
        public int IdUsusario { get; set; }
        [Key]
        [Column("Id_comida")]
        public int IdComida { get; set; }
        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [ForeignKey("IdComida")]
        [InverseProperty("Carritos")]
        public virtual Comidum IdComidaNavigation { get; set; } = null!;
        [ForeignKey("IdUsusario")]
        [InverseProperty("Carritos")]
        public virtual Usuario IdUsusario1 { get; set; } = null!;
        [ForeignKey("IdUsusario")]
        [InverseProperty("Carritos")]
        public virtual Pedido IdUsusarioNavigation { get; set; } = null!;
    }
}
