using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.CommonUtils
{
   public static  class Common
    {


       // Date Time 
       public static int CalculateTotalDays(DateTime leaveDateFrom,DateTime leaveDateTo)
       {
           if (DateTime.Compare(leaveDateFrom, leaveDateTo) == 0)
               return 1;
          return  Convert.ToInt32((leaveDateTo - leaveDateFrom).TotalDays)+1;
       }

       public static bool IsNullOrDefault<T>(T value)
       {
           // Check for null for reference types
           if (value == null)
           {
               return true;
           }

           // Check for default values for value types
           var type = typeof(T);

           if (type.IsValueType)
           {
               // Get the default value for the type
               var defaultValue = Activator.CreateInstance(type);
               return value.Equals(defaultValue);
           }

           return false; // In case it is a reference type and not null
       }

    }
}
