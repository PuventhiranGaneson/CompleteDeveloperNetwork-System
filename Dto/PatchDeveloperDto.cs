namespace CompleteDeveloperNetwork_System.Dto
{
    public class PatchDeveloperDto
    {
        
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }

            public List<SkillsetDto>? Skillsets { get; set; }
            public List<HobbyDto>? Hobbies { get; set; }

    }
}
