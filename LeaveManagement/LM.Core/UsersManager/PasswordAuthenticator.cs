using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.UsersManager
{
   static class PasswordAuthenticator
    {


       public static bool VerifyPassword(string password, string encryptedPassword)
       {
           string encrypted =EncryptionService.EncryptPassword(password);
           if (encrypted.Equals(encryptedPassword))
           {
               return true;
           }
           return false;
       }



 
    }
}
