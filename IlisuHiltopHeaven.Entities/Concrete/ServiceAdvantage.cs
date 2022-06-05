using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class ServiceAdvantage
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int AdvantageId { get; set; }
        public Advantage Advantage { get; set; }
    }
}
