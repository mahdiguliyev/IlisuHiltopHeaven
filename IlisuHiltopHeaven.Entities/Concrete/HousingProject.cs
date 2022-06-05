using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class HousingProject
    {
        public virtual int Id { get; set; }
        public string MainTitle { get; set; }
        public string Description { get; set; }
        public string floor1 { get; set; }
        public string floor2 { get; set; }
        public string floor3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
    }
}
