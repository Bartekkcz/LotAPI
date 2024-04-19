using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdatePlaneDto
    {
        /* Only the departure date and aircraft type can be updated */
        public int Id {  get; set; }
        public DateTime? DepartureDate { get; set; }   
        public string PlaneType { get; set; }
    }
}
