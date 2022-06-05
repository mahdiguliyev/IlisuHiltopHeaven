using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class SocialMedia
    {
        public virtual int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string YoutubeUrl { get; set; }
    }
}
