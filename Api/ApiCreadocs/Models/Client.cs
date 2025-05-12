using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Client
    {
        [Key]
        public int id_Cli { get; set; }
        public int id_sexe { get; set; }
        public int id_ville { get; set; }
        public int? id_regimeSecu { get; set; }
        public string nomCli { get; set; }
        public string prenomCli { get; set; }
        public string numIdCli { get; set; }
        public string? telCli { get; set; }
        public string? mailCli { get; set; }
        public int? depNaIssCli { get; set; }
        public DateTime? dateNaissCli { get; set; }
        public string? add1Cli { get; set; }
        public string? add2Cli { get; set; }
        public string? add3Cli { get; set; }
        public string? numCompteCli { get; set; }
        public string? numSecuCli { get; set; }
    }
}
