using System;
using System.Security.Cryptography;
using System.Text;

namespace FTPPasswordCryptographyApp
{
    public class CryptographyEngine
    {
        private static readonly byte[] CryptographyKey = Encoding.ASCII.GetBytes("FtPpa$$w0rD");
        private static readonly byte[] CryptographyPasswordLevel = Encoding.ASCII.GetBytes("Pa$$w0rD");


        private static string EncryptionString(string value, byte[] encryotionLevel)
        {
            byte[] inBytes = Encoding.Unicode.GetBytes(value);
            RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider();
            ICryptoTransform encryptor = csp.CreateEncryptor(CryptographyKey, encryotionLevel);

            byte[] outByte = encryptor.TransformFinalBlock(inBytes, 0, inBytes.Length);
            return Convert.ToBase64String(outByte);
        }

        private static string DecryptionString(string value, byte[] decryptionLevel)
        {
            byte[] inBytes = Convert.FromBase64String(value);
            RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider();
            ICryptoTransform decryptor = csp.CreateDecryptor(CryptographyKey, decryptionLevel);

            byte[] outByte = decryptor.TransformFinalBlock(inBytes, 0, inBytes.Length);
            return Encoding.Unicode.GetString(outByte);
        }
        public static string EncryptionFtpPassword(string value)
        {
            //(UtcDate | Password | UtcTime)
            return EncryptionString(string.Format("{0}æ{1}æ{2}æ{3}", DateTime.UtcNow.ToString("yyyy-MM-dd"),
                value, DateTime.UtcNow.ToString("HH:mm:ss"), "FTP"), CryptographyPasswordLevel);
        }
        public static string DecryptionFtpPassword(string value)
        {
            
            string[] val = DecryptionString(value, CryptographyPasswordLevel).Split('æ');
            DateTime returnDate;
            if (val.Length == 4) //must have 3 sets (UtcDate | Password | UtcTime | FTP)
                if (DateTime.TryParse(val[0] + ' ' + val[2], out returnDate)) //Should be a valid date
                    if (val[3] == "FTP")
                        return val[1];

            return null;
        }
    }
}
