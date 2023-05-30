using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    public partial class Comidum
    {
        public Comidum()
        {
            Carritos = new HashSet<Carrito>();
            DetalleDePedidos = new HashSet<DetalleDePedido>();
            Reseñas = new HashSet<Reseña>();
        }

        [Key]
        [Column("id_comida")]
        public int IdComida { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("descripcion")]
        [StringLength(300)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        [Column("precio", TypeName = "numeric(18, 0)")]
        public decimal Precio { get; set; }
        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        [InverseProperty("Comida")]
        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        [ForeignKey("IdComida")]
        [InverseProperty("Comidum")]
        public virtual RolCliente IdComidaNavigation { get; set; } = null!;
        [InverseProperty("IdComidaNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdComidaNavigation")]
        public virtual ICollection<DetalleDePedido> DetalleDePedidos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Reseña> Reseñas { get; set; }
    }
}
