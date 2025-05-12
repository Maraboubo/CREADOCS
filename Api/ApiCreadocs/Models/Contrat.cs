using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Contrat
    {
        [Key]
        public int id_Contr { get; set; }
        public int id_typContr { get; set; }
        public int? numCarte { get; set; }
        public int id_inter { get; set; }
        public int id_Cli { get; set; }
        public int? id_Assu { get; set; }
        public int? id_Mutu { get; set; }
        public int? numSim { get; set; }
        public DateTime dateContr { get; set; }
        public DateTime? dateDebutContr { get; set; }
        public DateTime? dateFinContr { get; set; }
        public string? fichierContr { get; set; }
    }
}
