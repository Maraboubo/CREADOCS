using System.ComponentModel.DataAnnotations;


namespace ApiCreadocs.Models
{
    public class Agence
    {
        [Key]
        public int id_agence { get; set; }
        public string nomAgence { get; set; }
        public string nomDirAgence { get; set;}
        public string prenomDirAgence { get; set; }
    }
}
