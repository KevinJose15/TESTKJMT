using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJMT.Manipulaciones
{
    public class KJMTStringManipulator
    {
        public string ReverseString(string input)
        {
            // Implementa la inversión de la cadena
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string RemoveSpaces(string input)
        {
            // Implementa la eliminación de espacios en blanco (solo ' ')
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Replace(" ", string.Empty);
        }
    }
}
