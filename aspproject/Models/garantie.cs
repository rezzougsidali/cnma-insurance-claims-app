using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class garantie
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        [Column("contrat_id")]
        
        public long ContratId { get; set; }
        //[ForeignKey("ContratId")]

        //public virtual detail_contrat Contrat { get; set; }

        [Column("code_garantie")]
        public string CodeGarantie { get; set; }
        public double Capital { get; set; }

        public double Majoration { get; set; }

        public double Reduction { get; set; }
        [Column("prime_nette")]
        public double PrimeNette { get; set; }
    }
}
