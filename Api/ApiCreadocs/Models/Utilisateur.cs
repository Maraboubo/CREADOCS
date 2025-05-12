using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Utilisateur
    {
        [Key]
        public int id_Utilisateur { get; set; }
        public int? idStatut { get; set; }
        public int id_vCode { get; set; }
        public string uNom { get; set; }
        public string uPrenom { get; set; }
        public string Email { get; set; }
        public string uIdentifiant { get; set; }
        public string uMotDePasse { get; set; }
        public string Adresse1 { get; set; }
        public string? Adresse2 { get; set; }
        public byte[]? uPhoto { get; set; }
    }
}
