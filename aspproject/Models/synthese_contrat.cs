 using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class synthese_contrat
    {
        public int Id { get; set; }
        public int CrmaId { get; set; }
        public int BrancheId { get; set; }
        public int Exercice { get; set; }
        public decimal PrimeCommerciale { get; set; }
        public decimal Creances { get; set; }
        public decimal CapitalAssure { get; set; }
        public decimal CotisationNette { get; set; }
        public int NombreContrat { get; set; }
        public int NombreAvenants { get; set; }
    }
}
