using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InternetBankaciligi.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("TC Kimlik Numarası")]
        public string TCNo { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [DisplayName("Şifre")]
        public string UserPassword { get; set; }
    }
}
