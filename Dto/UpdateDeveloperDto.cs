public class UpdateDeveloperDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int IsActive { get; set; }
    public List<SkillsetDto> Skillsets { get; set; }
    public List<HobbyDto> Hobbies { get; set; }
}

public class SkillsetsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DeveloperId { get; set; }
}

public class HobbiesDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DeveloperId { get; set; }
}
