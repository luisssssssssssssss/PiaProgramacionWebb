using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    [Table("Rol_Cliente")]
    public partial class RolCliente
    {
        [Column("id_usuarios")]
        public int IdUsuarios { get; set; }
        [Key]
        [Column("id_rolcliente")]
        public int IdRolcliente { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("apellido")]
        [StringLength(50)]
        [Unicode(false)]
        public string Apellido { get; set; } = null!;
        [Column("id_pedido")]
        public int? IdPedido { get; set; }
        [Column("telefono")]
        [StringLength(25)]
        [Unicode(false)]
        public string Telefono { get; set; } = null!;
        [Column("id_rol")]
        public int IdRol { get; set; }

        [InverseProperty("IdComidaNavigation")]
        public virtual Comidum? Comidum { get; set; }
    }
}
