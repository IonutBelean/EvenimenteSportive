using System.ComponentModel.DataAnnotations;

namespace EvenimenteSportive.Models
{
    public class Locatie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(100, ErrorMessage = "Numele nu poate avea mai mult de 100 de caractere.")]
        public string Nume { get; set; }

        [StringLength(200, ErrorMessage = "Adresa nu poate avea mai mult de 200 de caractere.")]
        public string Adresa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacitatea trebuie sa fie mai mare decat 0.")]
        public int Capacitate { get; set; }
    }
}
