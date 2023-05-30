using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    [Table("Detalle_de_Pedido")]
    public partial class DetalleDePedido
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Key]
        [Column("id_comida")]
        public int IdComida { get; set; }
        [Column("cantidad", TypeName = "decimal(18, 0)")]
        public decimal Cantidad { get; set; }
        [Column("precio", TypeName = "decimal(18, 0)")]
        public decimal Precio { get; set; }
        [Column("subtotal", TypeName = "decimal(18, 0)")]
        public decimal Subtotal { get; set; }

        [ForeignKey("IdComida")]
        [InverseProperty("DetalleDePedidos")]
        public virtual Comidum IdComidaNavigation { get; set; } = null!;
        [ForeignKey("IdPedido")]
        [InverseProperty("DetalleDePedidos")]
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}
