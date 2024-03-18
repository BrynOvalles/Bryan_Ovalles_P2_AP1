using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class PersonasDetalles
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Este Campo Es Obligatorio.")]
    public int PersonaId { get; set; }
    [Required(ErrorMessage = "Este Campo Es Obligatorio.")]
    public int TipoId { get; set; }
    [Required(ErrorMessage = "Este Campo Es Obligatorio.")]
    public string Telefono { get; set; } = string.Empty;


}
