namespace ParisApp.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public LocationDTO Location { get; set; }
        public List<PersonDTO> Athletes { get; set; }
    }
}
