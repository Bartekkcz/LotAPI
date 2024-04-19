using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PlaneDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public string PlaneType { get; set; }

        
    }
}
