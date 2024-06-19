namespace ParisApp.DTOs
{
    public interface IPersonDTO
    {
        int Id { get; set; }
        string Identification { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string BirthDate { get; set; }
        string Country { get; set; }
        string Type { get; set; }
    }
}
