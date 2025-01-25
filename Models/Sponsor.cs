using EvenimenteSportive.Models;
using System.ComponentModel.DataAnnotations;

public class Sponsor
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Numele sponsorului este obligatoriu.")]
    [StringLength(100, ErrorMessage = "Numele nu poate avea mai mult de 100 de caractere.")]
    public string Nume { get; set; }

    [Required(ErrorMessage = "Bugetul este obligatoriu.")]
    [Range(1, double.MaxValue, ErrorMessage = "Bugetul trebuie sa fie mai mare decat 0.")]
    public decimal Buget { get; set; }

    [Required(ErrorMessage = "Durata contractului este obligatorie.")]
    [Range(1, 120, ErrorMessage = "Durata contractului trebuie sa fie intre 1 si 120 luni.")]
    public int DurataContract { get; set; }

    [Required(ErrorMessage = "Evenimentul este obligatoriu.")]
    public int IDEveniment { get; set; }

    public EvenimentSportiv EvenimentSportiv { get; set; }
}
