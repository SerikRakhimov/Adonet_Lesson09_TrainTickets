using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets
{
    public class Car:Entity
    {
        public string Number { get; set; }
        public int? TrainId { get; set; }
        public Train Train { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}
