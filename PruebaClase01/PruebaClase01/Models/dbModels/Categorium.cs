using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaClase01.Models.dbModels
{
    public partial class Categorium
    {
        public Categorium()
        {
            Comida = new HashSet<Comidum>();
        }

        [Key]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("descripción")]
        [StringLength(50)]
        [Unicode(false)]
        public string Descripción { get; set; } = null!;

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Comidum> Comida { get; set; }
    }
}
