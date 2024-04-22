using Application.Dto;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreatePlaneDtoValidator : AbstractValidator<CreatePlaneDto>
    {
        private readonly IUserRepository _userRepository;
        public CreatePlaneDtoValidator()
        {   }

        public CreatePlaneDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(plane => plane.FlightNumber)
                .NotEmpty().WithMessage("Flight number is required.")
                .MaximumLength(5).WithMessage("Flight number must not exceed 5 characters.")
                .Matches(@"^[A-Z]{2}\d{3}$").WithMessage("Flight number must be in the format XX999.");

            RuleFor(plane => plane.DeparturePlace)
                .NotEmpty().WithMessage("Departure place is required.")
                .Must(IsValidPlace).WithMessage("Invalid departure place.");

            RuleFor(plane => plane.ArrivalPlace)
                .NotEmpty().WithMessage("Arrival place is required.")
                .Must(IsValidPlace).WithMessage("Invalid arrival place.");

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

            bool IsValidPlace(string placeName)
            {
                var validPlaceNames = new[] { 
                    // Polish cities
                    "Warszawa", "Kraków", "Gdańsk", "Wrocław", "Katowice",
                    "Rzeszów", "Szczecin", "Bydgoszcz", "Lublin", "Łódź", "Poznań", 
        
                    // International cities
                    "New York", "Los Angeles", "London", "Paris", "Berlin",
                    "Tokyo", "Beijing", "Moscow", "Sydney", "Dubai"
                };

                return validPlaceNames.Contains(placeName);
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
