using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    [Table("Pedido")]
    public partial class Pedido
    {
        public Pedido()
        {
            Carritos = new HashSet<Carrito>();
            DetalleDePedidos = new HashSet<DetalleDePedido>();
        }

        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Column("id_usuarios")]
        public int IdUsuarios { get; set; }
        [Column("id_estado")]
        public int IdEstado { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("total_pagar", TypeName = "decimal(18, 0)")]
        public decimal TotalPagar { get; set; }
        [Column("lugar_recoger")]
        [StringLength(40)]
        public string LugarRecoger { get; set; } = null!;

        [ForeignKey("IdEstado")]
        [InverseProperty("Pedidos")]
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        [ForeignKey("IdPedido")]
        [InverseProperty("Pedido")]
        public virtual Usuario IdPedidoNavigation { get; set; } = null!;
        [InverseProperty("IdUsusarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<DetalleDePedido> DetalleDePedidos { get; set; }
    }
}
