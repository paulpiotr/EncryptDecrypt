using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// namespace EncryptDecrypt
/// </summary>
namespace EncryptDecrypt
{
    /// <summary>
    /// public class EncryptDecrypt
    /// </summary>
    public class EncryptDecrypt
    {
        /// <summary>
        /// private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// </summary>
        //private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// public static string EncryptString(string text, string salt)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string EncryptString(string text, string salt)
        {
            try
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = Encoding.UTF8.GetBytes(salt);
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (Aes aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateEncryptor(key, aes.IV))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write))
                            {
                                using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                                {
                                    streamWriter.Write(text);
                                }
                                byte[] iv = aes.IV;
                                byte[] decryptedContent = memoryStream.ToArray();
                                byte[] result = new byte[iv.Length + decryptedContent.Length];
                                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                                Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                                return Convert.ToBase64String(result);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// public static string DecryptString(string text, string salt)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string DecryptString(string text, string salt)
        {
            try
            {
                byte[] fromBase64String = Convert.FromBase64String(text);
                byte[] iv = new byte[16];
                byte[] cipher = new byte[fromBase64String.Length - iv.Length];
                Buffer.BlockCopy(fromBase64String, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fromBase64String, iv.Length, cipher, 0, cipher.Length);
                byte[] key = Encoding.UTF8.GetBytes(salt);
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (Aes aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateDecryptor(key, iv))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipher))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Read))
                            {
                                using (StreamReader streamReader = new StreamReader(cryptoStream))
                                {
                                    return streamReader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// public static string GetRsaFilePath(string path = null, string file = null)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetRsaFilePath(string path = null, string file = null)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path ?? AppDomain.CurrentDomain.BaseDirectory);
                while (null != directoryInfo && !directoryInfo.GetFiles((null != file ? file : "public.rsa")).Any())
                {
                    directoryInfo = directoryInfo.Parent;
                }
                path = Path.Combine(null != directoryInfo ? directoryInfo.FullName : AppDomain.CurrentDomain.BaseDirectory, (null != file ? file : "public.rsa"));
                return path;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// public static string GetRsaFileContent()
        /// </summary>
        /// <returns></returns>
        public static string GetRsaFileContent()
        {
            try
            {
                return File.ReadAllText(GetRsaFilePath());
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Pobierz treść klucza z pliku według nazwy pliku
        /// </summary>
        /// <param name="file">Nazwa pliku AS string</param>
        /// <returns>Treść klucza z pliku AS string</returns>
        public static string GetRsaFileContent(string file)
        {
            try
            {
                return File.ReadAllText(GetRsaFilePath(null, file));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
