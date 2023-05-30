using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("id_estado")]
        public int IdEstado { get; set; }
        [Column("Nombre_estado")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreEstado { get; set; } = null!;

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
