namespace ParisApp.DTOs
{
    public class CompetitionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
