using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CompleteDeveloperNetwork_System.Models
{
    public class Developers
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //many
        public ICollection<Skillsets> skillsets { get; set; }
        public ICollection<Hobbies> hobbies { get; set; }
    }
}
