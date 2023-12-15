﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)
        {
            //base demek inherit ettiğimiz Yani Result

        }
        public ErrorResult() : base(false)
        {
            //mesaj vermeyip sadece false döndürmek istediğimizde kullanırız.

        }
    }
}
