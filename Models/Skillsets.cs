namespace CompleteDeveloperNetwork_System.Models
{
    public class Skillsets
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int DeveloperId { get; set; } // same as id in developer table
        public Developers developer { get; set; }
    }
}
