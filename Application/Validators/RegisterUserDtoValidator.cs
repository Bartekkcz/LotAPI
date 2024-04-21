using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using FluentValidation;
using System.Linq;

namespace Application.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .MaximumLength(320).WithMessage("Email address must not exceed 320 characters.");

            RuleFor(user => user.PasswordHash).MinimumLength(8);

            RuleFor(user => user.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = userRepository.GetALL().Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email already in use!");
                    }
                });

            RuleFor(user => user.RoleId)
                .InclusiveBetween(1, 3)
                .WithMessage("RoleId must be between 1 and 3.");
        }
    }
}
