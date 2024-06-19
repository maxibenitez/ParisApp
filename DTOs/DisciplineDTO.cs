namespace ParisApp.DTOs
{
    public class DisciplineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CompetitionDTO> Competitions { get; set; }
    }
}
