using UserService.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UserService.Infrastructure.Services
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _keyCryptography;

        public CryptographyService(IConfiguration configuration)
        {
            _configuration = configuration;
            _keyCryptography = Encoding.ASCII.GetBytes(_configuration.GetSection("SecretKeyCryptography").Value);
        }

        public string Encrypt(object valueInput)
        {
            String value = JsonConvert.SerializeObject(valueInput);

            if (value == null || value.Length <= 0)
            {
                throw new ArgumentNullException("É obrigatório passar um valor a ser criptografado");
            }

            byte[] encrypted;
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = _keyCryptography;
                rijAlg.IV = _keyCryptography;
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(value);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string input)
        {
            byte[] value = Encoding.ASCII.GetBytes(input);

            if (value == null || value.Length <= 0)
            {
                throw new ArgumentNullException("É obrigatório passar um valor a ser descriptografado");
            }

            string textClean = null;
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = _keyCryptography;
                rijAlg.IV = _keyCryptography;
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (var msDecrypt = new MemoryStream(value))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            textClean = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return textClean;
        }
    }
}
