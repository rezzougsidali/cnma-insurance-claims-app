namespace aspproject.Models.c
{
    public class DashboardViewModel
    {
         
        public int SelectedCrmaId { get; set; }
        public int SelectedExercice { get; set; }
        public List<crma> Crmas { get; set; }
        public List<int> Exercices { get; set; }
        public SummaryData Summary { get; set; }
        public List<BranchDetail> BranchDetails { get; set; }
        //changes2
        public ClaimSummaryData ClaimSummary { get; set; }
        public List<ClaimBranchDetail> ClaimBranchDetails { get; set; }
    }

    public class SummaryData
    {
        public decimal TotalPrimeCommerciale { get; set; }
        public decimal TotalCreances { get; set; }
        public decimal TotalCapitalAssure { get; set; }
        public decimal TotalCotisationNette { get; set; }
        public int TotalNombreContrat { get; set; }
        public int TotalNombreAvenants { get; set; }
    }

    public class BranchDetail
    {
        public string BranchName { get; set; }
        public decimal PrimeCommerciale { get; set; }
        public decimal Creances { get; set; }
        public decimal CapitalAssure { get; set; }
        public decimal CotisationNette { get; set; }
        public int NombreContrat { get; set; }
        public int NombreAvenants { get; set; }
    }
    //changes2
    public class ClaimSummaryData
    {
        public int TotalDossiersOuverts { get; set; }
        public int TotalNombreReserve { get; set; }
        public decimal TotalMontantReserve { get; set; }
        public int TotalNombreReglement { get; set; }
        public decimal TotalMontantReglement { get; set; }
        public int TotalNombreSap { get; set; }
        public decimal TotalMontantSap { get; set; }
    }

    public class ClaimBranchDetail
    {
        public string BranchName { get; set; }
        public int DossiersOuverts { get; set; }
        public int NombreReserve { get; set; }
        public decimal MontantReserve { get; set; }
        public int NombreReglement { get; set; }
        public decimal MontantReglement { get; set; }
        public int NombreSap { get; set; }
        public decimal MontantSap { get; set; }
    }
}

