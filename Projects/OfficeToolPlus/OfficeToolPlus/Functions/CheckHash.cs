using System.IO;
using System.Text;

namespace OTP.Functions
{
    class CheckHash
    {
        private readonly string hashValue;

        /// <summary>
        /// Hash 值检查
        /// </summary>
        /// <param name="resFile">文件路径</param>
        /// <param name="type">Hash 值的类型</param>
        public CheckHash(string resFile, HashType type)
        {
            hashValue = string.Empty;
            byte[] retVal = null;
            FileStream file = new FileStream(resFile, FileMode.Open);
            switch (type)
            {
                case HashType.MD5:
                    System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    retVal = MD5Hash.ComputeHash(file);
                    break;
                case HashType.SHA1:
                    System.Security.Cryptography.SHA1CryptoServiceProvider SHA1Hash = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                    retVal = SHA1Hash.ComputeHash(file);
                    break;
                case HashType.SHA256:
                    System.Security.Cryptography.SHA256CryptoServiceProvider SHA256Hash = new System.Security.Cryptography.SHA256CryptoServiceProvider();
                    retVal = SHA256Hash.ComputeHash(file);
                    break;
                case HashType.SHA384:
                    System.Security.Cryptography.SHA384CryptoServiceProvider SHA384Hash = new System.Security.Cryptography.SHA384CryptoServiceProvider();
                    retVal = SHA384Hash.ComputeHash(file);
                    break;
                case HashType.SHA512:
                    System.Security.Cryptography.SHA512CryptoServiceProvider SHA512Hash = new System.Security.Cryptography.SHA512CryptoServiceProvider();
                    retVal = SHA512Hash.ComputeHash(file);
                    break;
            }
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            hashValue = sb.ToString();
        }

        /// <summary>
        /// 比对 Hash 值是否匹配，如果匹配，返回 True，否则返回 False
        /// </summary>
        /// <param name="resValue">要比较的 Hash 值</param>
        /// <returns></returns>
        public bool CheckVaule(string resValue)
        {
            if (hashValue != resValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取 Hash 值
        /// </summary>
        /// <returns></returns>
        public string GetHashValue()
        {
            return hashValue;
        }
    }

    /// <summary>
    /// 哈希值的类型
    /// </summary>
    public enum HashType
    {
        MD5 = 0,
        SHA1 = 1,
        SHA256 = 2,
        SHA384 = 3,
        SHA512 = 4,
    }
}
