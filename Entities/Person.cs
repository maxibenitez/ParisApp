﻿namespace ParisApp.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public int IdDiscipline { get; set; }
        public string Type { get; set; }
    }
}
