using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Converter = TESTKJMT.KJMTTemperatureConverter;     


namespace TESTKJMT.Temperatura.Tests 
{
    public class KJMTTemperatureConverterXunitTests
    {

        private readonly Converter _converter;

        public KJMTTemperatureConverterXunitTests()
        {
            _converter = new Converter();
        }

        // *** Pruebas para CelsiusToFahrenheit ***

        [Fact(DisplayName = "Verifica la conversión de 0°C a 32°F (Punto de congelación).")]
        public void CelsiusToFahrenheit_Zero_ReturnsThirtyTwo()
        {
            double celsius = 0.0;
            double expectedFahrenheit = 32.0;

            double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

            // Tolerancia 0.001 ~ mismo espíritu que MSTest con delta
            Assert.InRange(actualFahrenheit, expectedFahrenheit - 0.001, expectedFahrenheit + 0.001);
        }

        [Fact(DisplayName = "Verifica la conversión de 100°C a 212°F (Punto de ebullición).")]
        public void CelsiusToFahrenheit_OneHundred_ReturnsTwoTwelve()
        {
            double celsius = 100.0;
            double expectedFahrenheit = 212.0;

            double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

            Assert.InRange(actualFahrenheit, expectedFahrenheit - 0.001, expectedFahrenheit + 0.001);
        }

        [Fact(DisplayName = "Verifica el punto de coincidencia: -40°C a -40°F.")]
        public void CelsiusToFahrenheit_NegativeForty_ReturnsNegativeForty()
        {
            double celsius = -40.0;
            double expectedFahrenheit = -40.0;

            double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

            Assert.InRange(actualFahrenheit, expectedFahrenheit - 0.001, expectedFahrenheit + 0.001);
        }

        // *** Pruebas para FahrenheitToCelsius ***

        [Fact(DisplayName = "Verifica la conversión de 32°F a 0°C (Punto de congelación).")]
        public void FahrenheitToCelsius_ThirtyTwo_ReturnsZero()
        {
            double fahrenheit = 32.0;
            double expectedCelsius = 0.0;

            double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

            Assert.InRange(actualCelsius, expectedCelsius - 0.001, expectedCelsius + 0.001);
        }

        [Fact(DisplayName = "Verifica la conversión de 212°F a 100°C (Punto de ebullición).")]
        public void FahrenheitToCelsius_TwoTwelve_ReturnsOneHundred()
        {
            double fahrenheit = 212.0;
            double expectedCelsius = 100.0;

            double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

            Assert.InRange(actualCelsius, expectedCelsius - 0.001, expectedCelsius + 0.001);
        }

        [Fact(DisplayName = "Verifica el punto de coincidencia: -40°F a -40°C.")]
        public void FahrenheitToCelsius_NegativeForty_ReturnsNegativeForty()
        {
            double fahrenheit = -40.0;
            double expectedCelsius = -40.0;

            double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

            Assert.InRange(actualCelsius, expectedCelsius - 0.001, expectedCelsius + 0.001);
        }
    }
}

