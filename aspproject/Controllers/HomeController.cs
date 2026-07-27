using System.Data;
using System.Diagnostics;
using aspproject.Models.c;
using aspproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ContratApp.Controllers
{
    //[Authorize(Roles = "Admin")] // All caps everywhere
    [Authorize]
    public class HomeController : Controller
    {
        private readonly string _connectionString;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MyConnection");
        }

        public IActionResult Index(int? crmaId, int? exercice)
        {
            var model = new DashboardViewModel
            {
                Crmas = GetCrmas(),
                Exercices = GetExercices(crmaId),
                SelectedCrmaId = crmaId ?? 0,
                SelectedExercice = exercice ?? 0
            };

            if (crmaId.HasValue && exercice.HasValue)
            {
                model.Summary = GetSummaryData(crmaId.Value, exercice.Value);
                model.BranchDetails = GetBranchDetails(crmaId.Value, exercice.Value);
                model.ClaimSummary = GetClaimSummaryData(crmaId.Value, exercice.Value);
                model.ClaimBranchDetails = GetClaimBranchDetails(crmaId.Value, exercice.Value);
            }

            return View(model);
        }

        private List<crma> GetCrmas()
        {
            var crmas = new List<crma>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"SELECT DISTINCT c.id, c.NomCRMA, c.CodeCRMA
                      FROM crma c
                      INNER JOIN synthese_contrat sc ON c.id = sc.crma_id
                      INNER JOIN synthese_volet_sinistre svs ON c.id = svs.crma_id AND svs.EXERCICES = sc.exercice
                      ORDER BY c.NomCRMA",
                    connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        crmas.Add(new crma
                        {
                            Id = reader.GetInt32("id"),
                            NomCRMA = reader.GetString("NomCRMA"),
                            CodeCRMA = reader.GetString("CodeCRMA")
                        });
                    }
                }
            }
            return crmas;
        }

        private List<int> GetExercices(int? crmaId)
        {
            var exercices = new List<int>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    crmaId.HasValue
                        ? @"SELECT DISTINCT sc.exercice
                            FROM synthese_contrat sc
                            INNER JOIN synthese_volet_sinistre svs ON sc.crma_id = svs.crma_id AND svs.EXERCICES = sc.exercice
                            WHERE sc.crma_id = @CrmaId
                            ORDER BY sc.exercice"
                        : @"SELECT DISTINCT sc.exercice
                            FROM synthese_contrat sc
                            INNER JOIN synthese_volet_sinistre svs ON sc.crma_id = svs.crma_id AND svs.EXERCICES = sc.exercice
                            ORDER BY sc.exercice",
                    connection);

                if (crmaId.HasValue)
                {
                    command.Parameters.AddWithValue("@CrmaId", crmaId.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exercices.Add(reader.GetInt32("exercice"));
                    }
                }
            }
            return exercices;
        }

        private SummaryData GetSummaryData(int crmaId, int exercice)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"SELECT 
                        SUM(prime_commerciale) AS TotalPrimeCommerciale,
                        SUM(creances) AS TotalCreances,
                        SUM(capital_assure) AS TotalCapitalAssure,
                        SUM(cotisation_nette) AS TotalCotisationNette,
                        SUM(nombre_contrat) AS TotalNombreContrat,
                        SUM(nombre_avenants) AS TotalNombreAvenants
                      FROM synthese_contrat
                      WHERE crma_id = @CrmaId AND exercice = @Exercice",
                    connection);

                command.Parameters.AddWithValue("@CrmaId", crmaId);
                command.Parameters.AddWithValue("@Exercice", exercice);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SummaryData
                        {
                            TotalPrimeCommerciale = reader.GetDecimal("TotalPrimeCommerciale"),
                            TotalCreances = reader.GetDecimal("TotalCreances"),
                            TotalCapitalAssure = reader.GetDecimal("TotalCapitalAssure"),
                            TotalCotisationNette = reader.GetDecimal("TotalCotisationNette"),
                            TotalNombreContrat = (int)reader.GetInt64("TotalNombreContrat"),
                            TotalNombreAvenants = (int)reader.GetInt64("TotalNombreAvenants")
                        };
                    }
                }
            }
            return null;
        }

        private List<BranchDetail> GetBranchDetails(int crmaId, int exercice)
        {
            var branchDetails = new List<BranchDetail>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"SELECT 
                        b.nom AS BranchName,
                        SUM(sc.prime_commerciale) AS PrimeCommerciale,
                        SUM(sc.creances) AS Creances,
                        SUM(sc.capital_assure) AS CapitalAssure,
                        SUM(sc.cotisation_nette) AS CotisationNette,
                        SUM(sc.nombre_contrat) AS NombreContrat,
                        SUM(sc.nombre_avenants) AS NombreAvenants
                      FROM synthese_contrat sc
                      INNER JOIN branche b ON sc.branche_id = b.id
                      WHERE sc.crma_id = @CrmaId AND sc.exercice = @Exercice
                      GROUP BY b.nom
                      ORDER BY b.nom",
                    connection);

                command.Parameters.AddWithValue("@CrmaId", crmaId);
                command.Parameters.AddWithValue("@Exercice", exercice);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        branchDetails.Add(new BranchDetail
                        {
                            BranchName = reader.GetString("BranchName"),
                            PrimeCommerciale = reader.GetDecimal("PrimeCommerciale"),
                            Creances = reader.GetDecimal("Creances"),
                            CapitalAssure = reader.GetDecimal("CapitalAssure"),
                            CotisationNette = reader.GetDecimal("CotisationNette"),
                            NombreContrat = (int)reader.GetInt64("NombreContrat"),
                            NombreAvenants = (int)reader.GetInt64("NombreAvenants")
                        });
                    }
                }
            }
            return branchDetails;
        }

        private ClaimSummaryData GetClaimSummaryData(int crmaId, int exercice)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"SELECT 
                        SUM(CAST(numero_dossiers_ouverts AS INT)) AS TotalDossiersOuverts,
                        SUM(CAST(nombre_reserve AS INT)) AS TotalNombreReserve,
                        SUM(CAST(montant_reserve AS DECIMAL(18,2))) AS TotalMontantReserve,
                        SUM(CAST(nombre_reglement AS INT)) AS TotalNombreReglement,
                        SUM(CAST(montant_reglement AS DECIMAL(18,2))) AS TotalMontantReglement,
                        SUM(CAST(nombre_sap AS INT)) AS TotalNombreSap,
                        SUM(CAST(montant_sap AS DECIMAL(18,2))) AS TotalMontantSap
                      FROM synthese_volet_sinistre
                      WHERE crma_id = @CrmaId AND EXERCICES = @Exercice
                        AND ISNUMERIC(numero_dossiers_ouverts) = 1
                        AND ISNUMERIC(nombre_reserve) = 1
                        AND ISNUMERIC(montant_reserve) = 1
                        AND ISNUMERIC(nombre_reglement) = 1
                        AND ISNUMERIC(montant_reglement) = 1
                        AND ISNUMERIC(nombre_sap) = 1
                        AND ISNUMERIC(montant_sap) = 1",
                    connection);

                command.Parameters.AddWithValue("@CrmaId", crmaId);
                command.Parameters.AddWithValue("@Exercice", exercice);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClaimSummaryData
                        {
                            TotalDossiersOuverts = reader.GetInt32("TotalDossiersOuverts"),
                            TotalNombreReserve = reader.GetInt32("TotalNombreReserve"),
                            TotalMontantReserve = reader.GetDecimal("TotalMontantReserve"),
                            TotalNombreReglement = reader.GetInt32("TotalNombreReglement"),
                            TotalMontantReglement = reader.GetDecimal("TotalMontantReglement"),
                            TotalNombreSap = reader.GetInt32("TotalNombreSap"),
                            TotalMontantSap = reader.GetDecimal("TotalMontantSap")
                        };
                    }
                }
            }
            return null;
        }

        private List<ClaimBranchDetail> GetClaimBranchDetails(int crmaId, int exercice)
        {
            var branchDetails = new List<ClaimBranchDetail>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"SELECT 
                        b.nom AS BranchName,
                        SUM(CAST(svs.numero_dossiers_ouverts AS INT)) AS DossiersOuverts,
                        SUM(CAST(svs.nombre_reserve AS INT)) AS NombreReserve,
                        SUM(CAST(svs.montant_reserve AS DECIMAL(18,2))) AS MontantReserve,
                        SUM(CAST(svs.nombre_reglement AS INT)) AS NombreReglement,
                        SUM(CAST(svs.montant_reglement AS DECIMAL(18,2))) AS MontantReglement,
                        SUM(CAST(svs.nombre_sap AS INT)) AS NombreSap,
                        SUM(CAST(svs.montant_sap AS DECIMAL(18,2))) AS MontantSap
                      FROM synthese_volet_sinistre svs
                      INNER JOIN branche b ON svs.branche_id = b.id
                      WHERE svs.crma_id = @CrmaId AND svs.EXERCICES = @Exercice
                        AND ISNUMERIC(svs.numero_dossiers_ouverts) = 1
                        AND ISNUMERIC(svs.nombre_reserve) = 1
                        AND ISNUMERIC(svs.montant_reserve) = 1
                        AND ISNUMERIC(svs.nombre_reglement) = 1
                        AND ISNUMERIC(svs.montant_reglement) = 1
                        AND ISNUMERIC(svs.nombre_sap) = 1
                        AND ISNUMERIC(svs.montant_sap) = 1
                      GROUP BY b.nom
                      ORDER BY b.nom",
                    connection);

                command.Parameters.AddWithValue("@CrmaId", crmaId);
                command.Parameters.AddWithValue("@Exercice", exercice);

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            branchDetails.Add(new ClaimBranchDetail
                            {
                                BranchName = reader.GetString("BranchName"),
                                DossiersOuverts = reader.GetInt32("DossiersOuverts"),
                                NombreReserve = reader.GetInt32("NombreReserve"),
                                MontantReserve = reader.GetDecimal("MontantReserve"),
                                NombreReglement = reader.GetInt32("NombreReglement"),
                                MontantReglement = reader.GetDecimal("MontantReglement"),
                                NombreSap = reader.GetInt32("NombreSap"),
                                MontantSap = reader.GetDecimal("MontantSap")
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _logger.LogWarning("Claims branch join failed: {Message}", ex.Message);
                    return new List<ClaimBranchDetail>();
                }
            }
            return branchDetails;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //[AllowAnonymous]
        //public async Task<IActionResult> DebugAuth([FromServices] UserManager<IdentityUser> userManager)
        //{
        //    var user = await userManager.GetUserAsync(User);
        //    var roles = user != null ? await userManager.GetRolesAsync(user) : new List<string>();

        //    return Json(new
        //    {
        //        IsAuthenticated = User.Identity?.IsAuthenticated,
        //        UserName = user?.UserName,
        //        Roles = roles,
        //        Claims = User.Claims.Select(c => new { c.Type, c.Value })
        //    });
        //}

    }
}
