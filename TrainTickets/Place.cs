using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets
{
    public class Place:Entity
    {
        public string Number { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public bool Pay { get; set; }
        public string CardNumber { get; set; }
        public string Fio { get; set; }
    }
}
