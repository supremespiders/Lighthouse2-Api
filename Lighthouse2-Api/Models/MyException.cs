using System;

namespace Lighthouse2_Api.Models
{
    public class MyException:Exception
    {
        public MyException(string message):base(message)
        {
                
        }
    }
}