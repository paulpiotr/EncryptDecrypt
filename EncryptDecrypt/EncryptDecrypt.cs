using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
        /// private readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// </summary>
        //private readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                var key = Encoding.UTF8.GetBytes(salt);
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (var aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateEncryptor(key, aes.IV))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Write))
                            {
                                using (var streamWriter = new StreamWriter(cryptoStream))
                                {
                                    streamWriter.Write(text);
                                }
                                var iv = aes.IV;
                                var decryptedContent = memoryStream.ToArray();
                                var result = new byte[iv.Length + decryptedContent.Length];
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
                var fromBase64String = Convert.FromBase64String(text);
                var iv = new byte[16];
                var cipher = new byte[fromBase64String.Length - iv.Length];
                Buffer.BlockCopy(fromBase64String, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fromBase64String, iv.Length, cipher, 0, cipher.Length);
                var key = Encoding.UTF8.GetBytes(salt);
                var mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key = mD5CryptoServiceProvider.ComputeHash(key);
                using (var aes = Aes.Create())
                {
                    using (ICryptoTransform iCryptoTransform = aes.CreateDecryptor(key, iv))
                    {
                        using (var memoryStream = new MemoryStream(cipher))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, iCryptoTransform, CryptoStreamMode.Read))
                            {
                                using (var streamReader = new StreamReader(cryptoStream))
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
                var directoryInfo = new DirectoryInfo(path ?? AppDomain.CurrentDomain.BaseDirectory);
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
                return Regex.Replace(File.ReadAllText(GetRsaFilePath()), @"\s+|\r+|\n+|\r\n+", string.Empty);
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
                return Regex.Replace(File.ReadAllText(GetRsaFilePath(null, file)), @"\s+|\r+|\n+|\r\n+", string.Empty);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
