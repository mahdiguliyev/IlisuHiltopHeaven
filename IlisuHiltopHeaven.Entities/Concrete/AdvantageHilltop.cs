using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class AdvantageHilltop
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        //public ICollection<ServiceAdvantage> ServiceAdvantages { get; set; }
        public ICollection<ServiceHiltopAdvantage> ServiceHiltopAdvantages { get; set; }
    }
}
