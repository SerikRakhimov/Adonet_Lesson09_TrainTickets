using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets
{
    public class Train:Entity
    {
        public string Number { get; set; }
        public string StationFrom { get; set; }
        public string StationTo { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
