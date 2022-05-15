using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace InternetBankaciligi.Host.Extensions
{
    public class IbanCalculator
    {
        private static string iban = string.Empty;
        enum TransformTable
        {
            A=10, B=11 ,C=12, D=13, E=14, F=15, G=16, H=17, I=18,
            J=19, K=20, L=21, M=22, N=23, O=24, P=25, Q=26, R=27,
            S=28, T=29, U=30, V=31, W=32, X=33, Y=34, Z=35
        }

        public static string GenerateIban(string customerNo)
        {
            string calculatedIban = customerNo + ((int)TransformTable.T).ToString() + ((int)TransformTable.R).ToString() + "00";
            var convertedIban = long.Parse(calculatedIban);

            int controlStep = 98 - (int)(convertedIban % 97);

            customerNo = "0000000000" + customerNo;
            iban = "TR" + controlStep.ToString() + "00015" + "0" + customerNo;
            /*
             TR -> ülke koduS
             2 haneli kontrol basamağı ISO 7064 No'lu standarda göre MOD 97-10 yöntemi kullanılarak hesaplanır.
             Banka kodu -> uygulama içerisinde 15 olarak belirlendi. 0 ile padding yapıldı
             Rezerv Alan -> 0
             0 ile padding yapılmış 16 haneli müşteri numarası
             */

            return iban;
        }
    }
}
