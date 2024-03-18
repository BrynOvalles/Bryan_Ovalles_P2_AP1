using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Personas
{
    [Key]
    public int PersonaId { get; set; }
    [Required(ErrorMessage = "Este Campo Es Obligatorio.")]
    public string Nombres { get; set; } = string.Empty;

    [ForeignKey("Personas")]
    ICollection<PersonasDetalles> personasDetalles { get; set; } = new List<PersonasDetalles>();

}
