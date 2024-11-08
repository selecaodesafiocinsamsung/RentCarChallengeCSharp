using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarChallenge
{
    public class Car
    {
        public string Model { get; set; }
        public int Category { get; set; }
        public float Weekday { get; set; }

        public float Weekendday { get; set; }

        public float WeekdayFidelidade { get; set; }

        public float WeekenddayLoyalty { get; set; }
    }
}
