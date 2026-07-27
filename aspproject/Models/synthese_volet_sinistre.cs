using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class synthese_volet_sinistre
    {
        public int Id { get; set; }

        public int CrmaId { get; set; }
        public string NumeroSinistre { get; set; }

        public int NumeroDossiersOuverts { get; set; }
        public string NombreReserve { get; set; }
        public decimal MontantReserve { get; set; }

        public string NombreReglement { get; set; }

        public decimal MontantReglement { get; set; }

        public string NombreSap { get; set; }
        public decimal MontantSap { get; set; }
    }
}
