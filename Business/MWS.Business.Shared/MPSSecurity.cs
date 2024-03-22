using System.Security.Cryptography;
using System.Text;

namespace MWS.Business.Shared
{
    public class MPSSecurity
    {
        #region fields
        private const int slatSize = 128 / 8;
        private const int keySize = 256 / 8;
        private const int iteration = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        #endregion
        #region methods
        public static string Encrypt(string input, string key)
        {
            var inputArray = Encoding.UTF8.GetBytes(input);
            var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key.Substring(0, 16)),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDES.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(slatSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iteration, _hashAlgorithmName, keySize);
            return string.Join(';', Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }
        public static bool Verify(string passwordHash, string inputPassword)
        {
            var elements = passwordHash.Split(';');
            if (elements.Length > 1)
            {
                var salt = Convert.FromBase64String(elements[0]);
                var hash = Convert.FromBase64String(elements[1]);
                var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, iteration, _hashAlgorithmName, keySize);
                return CryptographicOperations.FixedTimeEquals(hash, hashInput);
            }
            return false;
        }
        public static string Decrypt(string input, string key)
        {
            var inputArray = Convert.FromBase64String(input);
            var tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key.Substring(0, 16)),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var cTransform = tripleDES.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
        #endregion

    }
}
