namespace CompleteDeveloperNetwork_System.Dto
{
    public class CreateDeveloperDto
    {
       
            public string Username { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime Udatetime { get; set; }
            public int IsActive { get; set; }

        public List<SkillsetDto> Skillsets { get; set; }
            public List<HobbyDto> Hobbies { get; set; }
        }

        public class SkillsetDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class HobbyDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

    
}
