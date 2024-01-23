using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMvcFissoloLorenzo.Models
{
    public class RichiestaRimboso
    {
        public int Id { get; set; }
        
        [StringLength(30, MinimumLength = 3)]
        public string? Nome { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string? Cognome { get; set; }

        
        [Display(Name = "Data Richiesta")]
        [DataType(DataType.Date)]
        public DateTime DataRichiesta { get; set; }

        public int Telefono { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? email { get; set; }

        [StringLength(11, MinimumLength = 3)]
        [Display(Name = "Partita Iva")]
        public string? PartitaIva { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Richiesta { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Importo { get; set; }
    }
}
