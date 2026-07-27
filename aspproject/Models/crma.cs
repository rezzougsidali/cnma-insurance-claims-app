using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace aspproject.Models
{
    public class crma
    {
        public int Id { get; set; }
        public string NomCRMA { get; set; }
        public string CodeCRMA { get; set; }
    }
}
