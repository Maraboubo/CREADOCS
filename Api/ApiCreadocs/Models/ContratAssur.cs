namespace ApiCreadocs.Models
{
    public class ContratAssur
    {
        public int? id_Contr {  get; set; }
        public int? id_TypContr { get; set; }
        public string? typeContr { get; set; }
        public int? id_inter { get; set; }
        public int? id_Cli { get; set; }
        public int? id_Assu { get; set; }
        public string? nomAssu { get; set; }
        public int? valeurAssu { get; set; }
        public DateTime? dateContr { get; set; }
        public DateTime? dateDebutContr { get; set; }
        public DateTime? dateFinContr { get; set; }
    }
}
