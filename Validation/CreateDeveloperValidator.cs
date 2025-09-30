//using CompleteDeveloperNetwork_System.Dto;
//using FluentValidation;

//public class CreateDeveloperValidator : AbstractValidator<DeveloperDto>
//{
//    public CreateDeveloperValidator()
//    {
//        RuleFor(d => d.Username)
//            .NotEmpty().WithMessage("Username is required");

//        RuleFor(d => d.Email)
//            .NotEmpty().EmailAddress();

//        RuleFor(d => d.PhoneNumber)
//            .NotEmpty().WithMessage("Phone number is required");

//        RuleFor(d => d.Skillsets)
//            .NotEmpty().WithMessage("At least one skillset is required");

//        RuleForEach(d => d.Skillsets).ChildRules(skill =>
//        {
//            skill.RuleFor(s => Username)
//                .NotEmpty().Matches(@"^[a-zA-Z#\+\s]+$")
//                .WithMessage("Skill name must be valid, e.g., 'C#', 'F#'");
//        });

//        RuleFor(d => d.Hobbies)
//            .NotEmpty().WithMessage("At least one hobby is required");

//        RuleForEach(d => d.Hobbies).ChildRules(hobby =>
//        {
//            hobby.RuleFor(h => h.Name)
//                .NotEmpty().WithMessage("Hobby name is required");
//        });
//    }
//}
