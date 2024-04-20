using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Planes")]
    public class Plane : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Flight number is required.")]
        [MaxLength(6, ErrorMessage = "Flight number must not exceed 6 characters.")]
        [RegularExpression("^LO\\d{3,4}$")]
        public string FlightNumber { get; set; }
        [Required(ErrorMessage = "Flight date is required.")]
        public DateTime? DepartureDate { get; set; }

        [Required(ErrorMessage = "Departure place is required.")]
        [MaxLength(50, ErrorMessage = "Departure place must not exceed 50 characters.")]
        public string DeparturePlace { get; set; }

        [Required(ErrorMessage = "Arrival place is required.")]
        [MaxLength(50, ErrorMessage = "Arrival place must not exceed 50 characters.")]
        public string ArrivalPlace { get; set; }

        [Required(ErrorMessage = "Plane type place is required.")]
        [MaxLength(50, ErrorMessage = "Plane type must not exceed 50 characters.")]
        public string PlaneType { get; set; }

        public Plane() { }

        public Plane(int id, string flightNumber, DateTime? departureDate, string departurePlace, string arrivalPlace, string planeType)
        {
            (Id, FlightNumber, DepartureDate, DeparturePlace, ArrivalPlace, PlaneType) = (id, flightNumber, departureDate, departurePlace, arrivalPlace, planeType);
        }
    }
}
