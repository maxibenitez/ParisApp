namespace ParisApp.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int IdDiscipline { get; set; }
        public int IdCompetition { get; set; }
        public int IdCategory { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public int IdLocation { get; set; }
    }
}
