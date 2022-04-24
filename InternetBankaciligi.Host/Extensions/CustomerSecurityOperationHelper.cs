using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace InternetBankaciligi.Host.Extensions
{
    public class CustomerSecurityOperationHelper
    {
        public static string GenerateCustomerNumber(string tcNo)
        {
            string customerNumer = string.Empty;
            customerNumer= tcNo.Substring(0, 6);

            return customerNumer;

        }

        public static string ComputeSha256HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string MaskTCNo(string tcNo)
        {
            string maskedTcNo = string.Empty;

            maskedTcNo = tcNo.Substring(0, 6) + "***" + tcNo.Substring(9, 2);
            return maskedTcNo;

        }
    }
}
