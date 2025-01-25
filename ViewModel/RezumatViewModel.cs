namespace EvenimenteSportive.ViewModels
{
    public class RezumatViewModel
    {
        public string EvenimentNume { get; set; }
        public DateTime EvenimentData { get; set; }
        public string LocatieNume { get; set; }
        public int LocatieCapacitate { get; set; }
        public List<string> Participanti { get; set; }
        public List<string> Sponsori { get; set; }
    }
}
