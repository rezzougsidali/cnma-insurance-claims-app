using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class detail_contrat
    {
        [Key]
        public long Id { get; set; }

        public int crma_id { get; set; }

        public int exercice { get; set; }

        public int assure_id { get; set; }

        public string numero_police { get; set; }
        
        public string date_police { get; set; }

        public double numero_contrat { get; set; }

        
        public string date_effet { get; set; }

       // [DataType(DataType.Date)]
        public string date_expiration { get; set; }
        public double prime_nette { get; set; }

        public double complement { get; set; }

        public double taxes { get; set; }

        public double timbres { get; set; }
        public double montant_net_a_payer { get; set; }

        public virtual ICollection<garantie> Garanties { get; set; }
    }
}
