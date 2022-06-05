using IlisuHiltopHeaven.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsAnswerd { get; set; } = false;
        public string PhoneNumber { get; set; }
    }
}
