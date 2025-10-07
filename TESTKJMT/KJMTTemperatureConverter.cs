using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTKJMT
{
    public class KJMTTemperatureConverter
    {
        private const double AbsoluteZeroC = -273.15;
        private const double AbsoluteZeroF = -459.67;

        public static double CelsiusToFahrenheit(double c)
        {
            if (c < AbsoluteZeroC)
                throw new ArgumentOutOfRangeException(nameof(c),
                    "No puede ser menor al cero absoluto (-273.15 °C).");
            return c * 9.0 / 5.0 + 32.0;
        }

        public static double FahrenheitToCelsius(double f)
        {
            if (f < AbsoluteZeroF)
                throw new ArgumentOutOfRangeException(nameof(f),
                    "No puede ser menor al cero absoluto (-459.67 °F).");
            return (f - 32.0) * 5.0 / 9.0;
        }

    }
}
