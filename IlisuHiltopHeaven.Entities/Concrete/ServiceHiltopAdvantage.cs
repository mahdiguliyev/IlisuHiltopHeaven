using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class ServiceHiltopAdvantage
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int AdvantageHiltopId { get; set; }
        public AdvantageHilltop AdvantageHilltop { get; set; }
    }
}
