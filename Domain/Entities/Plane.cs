using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Plane : AuditableEntity
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public string PlaneType { get; set; }

        public Plane() { }

        public Plane(int id, string flightNumber, DateTime? departureDate, string departurePlace, string arrivalPlace, string planeType)
        {
            (Id, FlightNumber, DepartureDate, DeparturePlace, ArrivalPlace, PlaneType) = (id, flightNumber, departureDate, departurePlace, arrivalPlace, planeType);
        }
    }
}
