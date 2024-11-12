﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core
{
    public class MyException<T> : Exception
    {
        public ActionResult<T> result;
        public MyException(ActionResult<T> result)
        {
            this.result = result;
        }
    }
}
