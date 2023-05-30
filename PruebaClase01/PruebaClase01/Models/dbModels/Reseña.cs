using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    public partial class Reseña
    {
        [Key]
        [Column("id_reseña")]
        public int IdReseña { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("id_comida")]
        public int IdComida { get; set; }
        [Column("comentario")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Comentario { get; set; }
        [Column("puntuación", TypeName = "decimal(18, 0)")]
        public decimal? Puntuación { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Reseñas")]
        public virtual Usuario IdUsuario1 { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Reseñas")]
        public virtual Comidum IdUsuarioNavigation { get; set; } = null!;
    }
}
