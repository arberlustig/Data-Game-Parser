using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{
    public static class Extension
    {

        public static bool checkIfReal(this string Input)
        {
            if(File.Exists(Input)) 
                    return true; 

            return false;
        }





    }
}
