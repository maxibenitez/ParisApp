namespace ParisApp.DTOs
{
    public abstract class PersonDTO : IPersonDTO
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
    }
}
