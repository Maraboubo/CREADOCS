using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Secu
    {
        [Key]
        public int id_regimeSecu { get; set; }
        public string nomRegimeSecu { get; set; }
    }
}
