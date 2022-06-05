using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Service
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PercentageOwner { get; set; }
        public int PercentageIHH { get; set; }
        public string Image { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public bool IsActive { get; set; } = true;
        public List<ServiceAdvantage> ServiceAdvantages { get; set; } = new List<ServiceAdvantage>();
        public List<ServiceHiltopAdvantage> ServiceHiltopAdvantages { get; set; } = new List<ServiceHiltopAdvantage>();
    }
}
