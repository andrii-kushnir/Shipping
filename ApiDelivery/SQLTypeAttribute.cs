using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery
{
    public class SQLTypeAttribute : Attribute
    {
        private string myName;
        public SQLTypeAttribute(string name)
        {
            myName = name;
        }
        public string Name
        {
            get
            {
                return myName;
            }
        }
    }
}
