using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Layer.Model.Common
{
    public static class DataEncryptionUtilities
    {
        public static string EncryptionKeyValue { get; set; }
        private static byte[] DESKey = { 200, 5, 78, 232, 9, 6, 0, 4 };
        private static byte[] DESInitializationVector = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static string GenerateEncryptedString(string value)
        {
            using (var cryptoProvider = new DESCryptoServiceProvider())
            using (var memoryStream = new MemoryStream())
            using (
                var cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateEncryptor(DESKey, DESInitializationVector), CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cryptoStream))
            {
                writer.Write(value);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        public static string GenerateDecryptedString(string value)
        {
            using (var cryptoProvider = new DESCryptoServiceProvider())
            using (var memoryStream = new MemoryStream(Convert.FromBase64String(value)))
            using (
                var cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateDecryptor(DESKey, DESInitializationVector), CryptoStreamMode.Read))
            using (var reader = new StreamReader(cryptoStream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GenerateKeyEncryptedString(string value)
        {
            var textconverter = new UTF8Encoding();
            var myAlg = new RijndaelManaged();
            var salt = Encoding.ASCII.GetBytes(EncryptionKeyValue);
            var key = new Rfc2898DeriveBytes(EncryptionKeyValue, salt);

            myAlg.Key = key.GetBytes(myAlg.KeySize / 8);
            myAlg.IV = key.GetBytes(myAlg.BlockSize / 8);
            var encryptor = myAlg.CreateEncryptor(myAlg.Key, myAlg.IV);
            var msEncrypt = new MemoryStream();
            var csEncrypted = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            var toEncrypted = textconverter.GetBytes(value);
            csEncrypted.Write(toEncrypted, 0, toEncrypted.Length);
            csEncrypted.FlushFinalBlock();

            var encrypted = msEncrypt.ToArray();
            return Convert.ToBase64String(encrypted);
        }

        public static string GenerateKeyDecryptedString(string encryptedText)
        {
            encryptedText = encryptedText.Replace(" ", "+");
            var decrypted = Convert.FromBase64String(encryptedText);
            var myAlg = new RijndaelManaged();
            var salt = Encoding.ASCII.GetBytes(EncryptionKeyValue);
            var key = new Rfc2898DeriveBytes(EncryptionKeyValue, salt);
            myAlg.Key = key.GetBytes(myAlg.KeySize / 8);
            myAlg.IV = key.GetBytes(myAlg.BlockSize / 8);

            var decryptor = myAlg.CreateDecryptor(myAlg.Key, myAlg.IV);
            var msDecrypt = new MemoryStream(decrypted);
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            var reader = new StreamReader(csDecrypt);
            return reader.ReadLine();
        }

        public static string HtmlEncode(this string text)
        {
            return Regex.Replace(text, "[^0-9a-zA-Z]+", "");
        }


    }
}
