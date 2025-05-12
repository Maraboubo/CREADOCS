namespace ApiCreadocs.Models
{
    public class ClientRetour
    {
        //ajout de id_ville pour la fonction update
        public int? id_Cli {  get; set; }
        public int? id_ville { get; set; }
        public string? numIdCli { get; set; }
        public string? nomCli { get; set; }
        public string? prenomCli { get; set; }
        public string? nomSexe { get; set; }
        public string? telCli { get; set; }
        public string? mailCli { get; set; }
        public int? depNaIssCli { get; set; }
        public DateTime? dateNaissCli { get; set; }
        public string? add1Cli { get; set; }
        public string? add2Cli { get; set; }
        public string? add3Cli { get; set; }
        public string? postalCode { get; set; }
        public string? placeName { get; set; }
        public string? countryCode { get; set; }
        public string? countryName { get; set; }
        public string? numCompteCli { get; set; }
        public string? numSecuCli { get; set; }
        public string? nomRegimeSecu { get; set; }
    }
}
