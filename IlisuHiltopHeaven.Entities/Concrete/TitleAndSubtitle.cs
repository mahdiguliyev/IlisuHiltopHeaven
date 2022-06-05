using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class TitleAndSubtitle
    {
        public virtual int Id { get; set; }
        public string Title1 { get; set; }
        public string Subtitle1 { get; set; }
        public string Title2 { get; set; }
        public string Subtitle2 { get; set; }
        public string Title3 { get; set; }
        public string Subtitle3 { get; set; }
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
