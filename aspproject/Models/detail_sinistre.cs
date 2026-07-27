using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class detail_sinistre
    {
        public int Id { get; set; }
        public string Numero_police { get; set; }

        public double Numero_sinistre { get; set; }

        public string Date_Sinistre { get; set; }
        public string Etat_Dossier { get; set; }

        public double Montant_Reserve { get; set; }

        public double Montant_Reglement { get; set; }
        public double Montant_Encaisse { get; set; }
        public long crma_id { get; set; }
        public long assure_id { get; set;}

    }
}
