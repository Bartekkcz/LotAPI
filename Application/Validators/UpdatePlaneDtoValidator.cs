using Application.Dto;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdatePlaneDtoValidator : AbstractValidator<UpdatePlaneDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePlaneDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(plane => plane.PlaneType)
                .NotEmpty().WithMessage("Plane type is required.")
                .Must(BeValidPlaneType).WithMessage("Invalid plane type.");

            RuleFor(plane => plane.DepartureDate)
                .NotEmpty().WithMessage("Departure date is required.")
                .Must(BeValidDate).WithMessage("Departure date must be in the format YYYY-MM-DD.");


            bool BeValidPlaneType(string planeType)
            {
                // List of PLL LOT fleet
                var validPlaneTypes = new[] { "Boeing 737", "Boeing 787 Dreamliner", "Embraer 170", "Embraer 175", "Embraer 190", "Embraer 195" };

                return validPlaneTypes.Contains(planeType);
            }

            bool BeValidDate(DateTime? date)
            {
                if (!date.HasValue)
                {
                    return false;
                }

                // Is date in the future?

                return true;
            }

        }
    }
}
