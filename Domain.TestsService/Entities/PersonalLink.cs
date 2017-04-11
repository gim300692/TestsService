using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestService.Domain.Entities
{
    public class PersonalLink
    {
        public int Id { get; set; }
        public string HashedPersonalLink { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int? TestSessionId { get; set; }


        public static string GetMd5Hash(MD5 md5hash, string input)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
