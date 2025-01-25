using System.ComponentModel.DataAnnotations;
using EvenimenteSportive.Models;

public class Participant
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Numele este obligatoriu.")]
    [StringLength(100, ErrorMessage = "Numele nu poate avea mai mult de 100 de caractere.")]
    public string Nume { get; set; }

    [Range(18, 60, ErrorMessage = "Varsta trebuie sa fie îitre 18 și 60.")]
    public int Varsta { get; set; }

    [Required(ErrorMessage = "Echipa este obligatorie.")]
    [StringLength(100, ErrorMessage = "Numele echipei nu poate avea mai mult de 100 de caractere.")]
    public string Echipa { get; set; }

    [Required(ErrorMessage = "Evenimentul este obligatoriu.")]
    public int IDEveniment { get; set; }
    public EvenimentSportiv EvenimentSportiv { get; set; }
}


