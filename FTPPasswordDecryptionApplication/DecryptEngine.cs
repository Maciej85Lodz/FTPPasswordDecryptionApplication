using System;
using System.Security.Cryptography;
using System.Text;

namespace FTPPasswordDecryptionApplication
{
    public class DecryptEngine
    {
        private static readonly byte[] CryptoKey = Encoding.ASCII.GetBytes("FtPa$$w0rD");
        private static readonly byte[] CryptoPasswordIv = Encoding.ASCII.GetBytes("Pa55w0rD");


        private static string EncryptString(string value, byte[] encryotionIv)
        {
            byte[] inBytes = Encoding.Unicode.GetBytes(value);
            RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider();
            ICryptoTransform encryptor = csp.CreateEncryptor(CryptoKey, encryotionIv);

            byte[] outByte = encryptor.TransformFinalBlock(inBytes, 0, inBytes.Length);
            return Convert.ToBase64String(outByte);
        }

        private static string DecryptString(string value, byte[] encryotionIv)
        {
            byte[] inBytes = Convert.FromBase64String(value);
            RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider();
            ICryptoTransform decryptor = csp.CreateDecryptor(CryptoKey, encryotionIv);

            byte[] outByte = decryptor.TransformFinalBlock(inBytes, 0, inBytes.Length);
            return Encoding.Unicode.GetString(outByte);
        }
        public static string EncryptFtpPassword(string value)
        {
            //æ - Alt+145
            //(UtcDate | Password | UtcTime)
            return EncryptString(string.Format("{0}æ{1}æ{2}æ{3}", DateTime.UtcNow.ToString("yyyy-MM-dd"),
                value, DateTime.UtcNow.ToString("HH:mm:ss"), "FTP"), CryptoPasswordIv);
        }
        public static string DecryptFtpPassword(string value)
        {
            //æ - Alt+145
            string[] val = DecryptString(value, CryptoPasswordIv).Split('æ');
            DateTime returnDate;
            if (val.Length == 4) //must have 3 sets (UtcDate | Password | UtcTime | FTP)
                if (DateTime.TryParse(val[0] + ' ' + val[2], out returnDate)) //Should be a valid date
                    if (val[3] == "FTP")
                        return val[1];

            return null;
        }
    }
}
