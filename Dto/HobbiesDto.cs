namespace CompleteDeveloperNetwork_System.Dto
{
    public class HobbiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeveloperId { get; set; } // same as id in developer table
    }
}
