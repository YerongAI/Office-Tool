using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OfficeTool.Functions
{
    //Copyright © 2020 Landiannews | By Yerong | https://otp.landian.vip/ | 2020/01/06
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
            FileStream file = new FileStream(resFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            switch (type)
            {
                case HashType.MD5:
                    MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                    retVal = MD5Hash.ComputeHash(file);
                    MD5Hash.Dispose();
                    break;
                case HashType.SHA1:
                    SHA1CryptoServiceProvider SHA1Hash = new SHA1CryptoServiceProvider();
                    retVal = SHA1Hash.ComputeHash(file);
                    SHA1Hash.Dispose();
                    break;
                case HashType.SHA256:
                    SHA256CryptoServiceProvider SHA256Hash = new SHA256CryptoServiceProvider();
                    retVal = SHA256Hash.ComputeHash(file);
                    SHA256Hash.Dispose();
                    break;
                case HashType.SHA384:
                    SHA384CryptoServiceProvider SHA384Hash = new SHA384CryptoServiceProvider();
                    retVal = SHA384Hash.ComputeHash(file);
                    SHA384Hash.Dispose();
                    break;
                case HashType.SHA512:
                    SHA512CryptoServiceProvider SHA512Hash = new SHA512CryptoServiceProvider();
                    retVal = SHA512Hash.ComputeHash(file);
                    SHA512Hash.Dispose();
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