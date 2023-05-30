using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    public partial class Usuario
    {
        public Usuario()
        {
            Carritos = new HashSet<Carrito>();
            Reseñas = new HashSet<Reseña>();
            IdRols = new HashSet<Role>();
        }

        [Key]
        [Column("id_usuarios")]
        public int IdUsuarios { get; set; }
        [Column("contraseña")]
        [StringLength(10)]
        public string Contraseña { get; set; } = null!;
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; } = null!;
        [Column("telefono")]
        [StringLength(25)]
        [Unicode(false)]
        public string Telefono { get; set; } = null!;
        [Column("correo_electronico")]
        [StringLength(50)]
        public string CorreoElectronico { get; set; } = null!;

        [InverseProperty("IdPedidoNavigation")]
        public virtual Pedido? Pedido { get; set; }
        [InverseProperty("IdUsusario1")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdUsuario1")]
        public virtual ICollection<Reseña> Reseñas { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("IdUsuarios")]
        public virtual ICollection<Role> IdRols { get; set; }
    }
}
