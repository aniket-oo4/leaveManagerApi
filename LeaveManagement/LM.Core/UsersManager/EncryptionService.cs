using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.UsersManager
{
   public static  class EncryptionService
    {


       static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

       public static string EncryptPassword(string password)
       {
           byte[] encrypted;

           string keyHex = "149B135F525434B77CB3BB063A11027FE06E9D48600E7C45C9DD3926C7FF4D66";
           string ivHex = "5AD19C8BA711DD6C36DE30A96D42F959";

           byte[] key = HexStringToByteArray(keyHex);
           byte[] iv = HexStringToByteArray(ivHex);

           using (Aes aes = Aes.Create())
           {
               encrypted = EncryptStringToBytes(password, key, iv);
           }
           return Convert.ToBase64String(encrypted);
       }


       static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
       {
           byte[] encrypted;

           // Create an Aes object with the specified key and IV.
           using (Aes aes = Aes.Create())
           {
               aes.Key = key;
               aes.IV = iv;

               // Create a new MemoryStream object to contain the encrypted bytes.
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   // Create a CryptoStream object to perform the encryption.
                   using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                   {
                       // Encrypt the plaintext.
                       using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                       {
                           streamWriter.Write(plainText);
                       }

                       encrypted = memoryStream.ToArray();
                   }
               }
           }

           return encrypted;
       }
      
       
       public   static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            string decrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Create a new MemoryStream object to contain the decrypted bytes.
                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    // Create a CryptoStream object to perform the decryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Decrypt the ciphertext.
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }


    }




   public sealed class AESHelper
   {
       private static string Encryptionkey = "$qVM2l]hac}.68.5}36(/${OY-qoq?~hyX%!E|w*o-Qr@|<3T5}4.FV;~}/UhC1";

       public static string EncryptData(string textData)
       {
           try
           {
               RijndaelManaged objrij = new RijndaelManaged();

               //set the mode for operation of the algorithm   
               objrij.Mode = CipherMode.CBC;

               //set the padding mode used in the algorithm.   
               objrij.Padding = PaddingMode.PKCS7;

               //set the size, in bits, for the secret key.   
               objrij.KeySize = 0x80;

               //set the block size in bits for the cryptographic operation.    
               objrij.BlockSize = 0x80;

               //set the symmetric key that is used for encryption & decryption.    
               byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);

               //set the initialization vector (IV) for the symmetric algorithm    
               byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

               int len = passBytes.Length;
               if (len > EncryptionkeyBytes.Length)
               {
                   len = EncryptionkeyBytes.Length;
               }

               Array.Copy(passBytes, EncryptionkeyBytes, len);

               objrij.Key = EncryptionkeyBytes;
               objrij.IV = EncryptionkeyBytes;

               //Creates a symmetric AES object with the current key and initialization vector IV.    
               ICryptoTransform objtransform = objrij.CreateEncryptor();
               byte[] textDataByte = Encoding.UTF8.GetBytes(textData);

               //Final transform the test string.  
               return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static string DecryptData(string EncryptedText)
       {
           try
           {
               RijndaelManaged objrij = new RijndaelManaged();
               objrij.Mode = CipherMode.CBC;
               objrij.Padding = PaddingMode.PKCS7;

               objrij.KeySize = 0x80;
               objrij.BlockSize = 0x80;

               byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);

               byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
               byte[] EncryptionkeyBytes = new byte[0x10];

               int len = passBytes.Length;
               if (len > EncryptionkeyBytes.Length)
               {
                   len = EncryptionkeyBytes.Length;
               }

               Array.Copy(passBytes, EncryptionkeyBytes, len);

               objrij.Key = EncryptionkeyBytes;
               objrij.IV = EncryptionkeyBytes;

               byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
               return Encoding.UTF8.GetString(TextByte);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
   }


  }


