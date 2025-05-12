using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Sexe
    {
        [Key]
        public int id_sexe { get; set; }
        public string abrSexe { get; set; }
        public string nomSexe { get; set; }
    }
}
