using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Services.Utilities
{
    public static class Messages
    {
        public static class Service
        {
            public static string NotFoundMessage(bool isPlural)
            {
                if (isPlural) return "Xidmət tapılmadı.";

                return "Xidmət tapılmadı.";
            }
            public static string AddMessage(string serviceTitle)
            {
                return $"{serviceTitle} xidməti əlavə edildi.";
            }
            public static string UpdateMessage(string serviceTitle)
            {
                return $"{serviceTitle} xidməti yeniləndi.";
            }
            public static string DeleteMessage(string serviceTitle)
            {
                return $"{serviceTitle} xidməti silindi.";
            }
        }
    }
}
