using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class assure

    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NumeroAssure { get; set; }

    }
}
