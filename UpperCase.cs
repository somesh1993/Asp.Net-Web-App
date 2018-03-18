using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDotnetApp.Model
{
    public class UpperCase
    {
        public string ChangeToUpperCase(string Name,string Email)
        {
            return Name.ToUpper() + "," + Email.ToUpper();
        }
    }
}