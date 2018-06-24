using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data
{
    public class Security
    {  //加密
        public static string Encryption(string express)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "oa_erp_dowork";//密匙容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
        }

        //解密
        public static string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "oa_erp_dowork";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
    }
}
