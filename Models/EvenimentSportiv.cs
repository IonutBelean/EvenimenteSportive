using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvenimenteSportive.Models;


namespace EvenimenteSportive.Models
{
    public class EvenimentSportiv
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Data este obligatorie.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Tipul este obligatoriu.")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "Locatia este obligatorie.")]
        public int IDLocatie { get; set; }
        public Locatie Locatie { get; set; }

        public ICollection<Sponsor> Sponsori { get; set; }
        public ICollection<Participant> Participanti { get; set; }

        public EvenimentSportiv()
        {
            Sponsori = new List<Sponsor>();
            Participanti = new List<Participant>();
        }
    }
}
