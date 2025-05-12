using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Titre
    {
        [Key]
        public int id_titre {  get; set; }
        public string nomTitre { get; set; }
    }
}
