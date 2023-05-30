using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    public partial class Role
    {
        public Role()
        {
            IdUsuarios = new HashSet<Usuario>();
        }

        [Column("Nombre_rol")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreRol { get; set; } = null!;
        [Key]
        [Column("id_rol")]
        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        [InverseProperty("IdRols")]
        public virtual ICollection<Usuario> IdUsuarios { get; set; }
    }
}
