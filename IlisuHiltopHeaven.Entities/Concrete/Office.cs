using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Office
    {
        public virtual int Id { get; set; }
        public string OfficeName { get; set; }
        public string Address { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
        public string Email { get; set; }
        public string WorkDays { get; set; }
        public string WorkHours { get; set; }
        public string MapUrl { get; set; }
        public bool IsMain { get; set; } = false;
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
    }
}
