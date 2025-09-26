namespace CompleteDeveloperNetwork_System.Dto
{
    public class UpdateDeveloperDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Udatetime { get; set; }

        public List<SkillsetDto> Skillsets { get; set; }
        public List<HobbyDto> Hobbies { get; set; }
    }
}
