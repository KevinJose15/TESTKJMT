using Microsoft.VisualStudio.TestTools.UnitTesting;
using TESTKJMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTKJMT.Tests
{
    [TestClass()]
    public class KJMTTemperatureConverterTests
    {
        [TestClass] // Atributo requerido por MSTest para identificar la clase de prueba
        public class TemperatureConverterTests
        {
            // Objeto de la clase a probar, inicializado en el método de inicialización
            private KJMTTemperatureConverter _converter;

            [TestInitialize] // Método que se ejecuta antes de cada prueba
            public void Setup()
            {
                _converter = new KJMTTemperatureConverter();
            }

            // *** Pruebas para CelsiusToFahrenheit ***

            [TestMethod]
            [Description("Verifica la conversión de 0°C a 32°F (Punto de congelación).")]
            public void CelsiusToFahrenheit_Zero_ReturnsThirtyTwo()
            {
                double celsius = 0.0;
                double expectedFahrenheit = 32.0;

                double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

                Assert.AreEqual(expectedFahrenheit, actualFahrenheit, 0.001, "0°C debe ser 32°F.");
            }

            [TestMethod]
            [Description("Verifica la conversión de 100°C a 212°F (Punto de ebullición).")]
            public void CelsiusToFahrenheit_OneHundred_ReturnsTwoTwelve()
            {
                double celsius = 100.0;
                double expectedFahrenheit = 212.0;

                double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

                Assert.AreEqual(expectedFahrenheit, actualFahrenheit, 0.001, "100°C debe ser 212°F.");
            }

            [TestMethod]
            [Description("Verifica el punto de coincidencia: -40°C a -40°F.")]
            public void CelsiusToFahrenheit_NegativeForty_ReturnsNegativeForty()
            {
                double celsius = -40.0;
                double expectedFahrenheit = -40.0;

                double actualFahrenheit = _converter.CelsiusToFahrenheit(celsius);

                Assert.AreEqual(expectedFahrenheit, actualFahrenheit, 0.001, "-40°C debe ser -40°F.");
            }

            // *** Pruebas para FahrenheitToCelsius ***

            [TestMethod]
            [Description("Verifica la conversión de 32°F a 0°C (Punto de congelación).")]
            public void FahrenheitToCelsius_ThirtyTwo_ReturnsZero()
            {
                double fahrenheit = 32.0;
                double expectedCelsius = 0.0;

                double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

                Assert.AreEqual(expectedCelsius, actualCelsius, 0.001, "32°F debe ser 0°C.");
            }

            [TestMethod]
            [Description("Verifica la conversión de 212°F a 100°C (Punto de ebullición).")]
            public void FahrenheitToCelsius_TwoTwelve_ReturnsOneHundred()
            {
                double fahrenheit = 212.0;
                double expectedCelsius = 100.0;

                double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

                Assert.AreEqual(expectedCelsius, actualCelsius, 0.001, "212°F debe ser 100°C.");
            }

            [TestMethod]
            [Description("Verifica el punto de coincidencia: -40°F a -40°C.")]
            public void FahrenheitToCelsius_NegativeForty_ReturnsNegativeForty()
            {
                double fahrenheit = -40.0;
                double expectedCelsius = -40.0;

                double actualCelsius = _converter.FahrenheitToCelsius(fahrenheit);

                Assert.AreEqual(expectedCelsius, actualCelsius, 0.001, "-40°F debe ser -40°C.");
            }
        }
    }
}
