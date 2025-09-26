namespace CompleteDeveloperNetwork_System.Dto
{
    public class DeveloperDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime Udatetime { get; set; }
        public int IsActive { get; set; }

        public List<string> Skillsets { get; set; }
        public List<string> Hobbies { get; set; }
    }
}
