using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Interlocuteur
    {
        [Key]
        public int id_inter {get; set;} 
        public int? id_titre { get; set;}
        public int? id_agence { get; set;}
        public string? loginInter {  get; set;}
        public string? mdpInter { get; set;}
        public string? loginKwInter { get; set;}
        public string? mdpKwInter { get; set;}
        public string nomInter { get; set; }
        public string prenomInter { get; set; }
        public string? telInter { get; set; }
        public string mailInter { get; set; }
        public string? nomAgence { get;set;}
        public string? nomDirAgence { get;set; }
        public string? prenomDirAgence { get;set; }
        public string? nomTitre { get;set; }
    }
}
