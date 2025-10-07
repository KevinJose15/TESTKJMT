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
        private static double R(double v) => Math.Round(v, 2);

        // ---- C -> F (casos típicos)
        [DataTestMethod]
        [DataRow(0, 32)]
        [DataRow(100, 212)]
        [DataRow(-40, -40)]
        [DataRow(37, 98.6)]
        [TestMethod()]
        public void celsiusToFahrenheitTest(double c, double expectedF)
        {
            var actual = R(KJMTTemperatureConverter.CelsiusToFahrenheit(c));
            Assert.AreEqual(expectedF, actual, 0.01, "Conversión C->F fuera de tolerancia.");
        }

        // ---- F -> C (casos típicos)
        [DataTestMethod]
        [DataRow(32, 0)]
        [DataRow(212, 100)]
        [DataRow(-40, -40)]
        [DataRow(98.6, 37)]
        public void FahrenheitToCelsius_OK(double f, double expectedC)
        {
            var actual = R(KJMTTemperatureConverter.FahrenheitToCelsius(f));
            Assert.AreEqual(expectedC, actual, 0.01, "Conversión F->C fuera de tolerancia.");
        }

        // ---- Errores por cero absoluto
        [TestMethod]
        public void CelsiusBelowAbsoluteZero_Throws()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => KJMTTemperatureConverter.CelsiusToFahrenheit(-300));
        }

        [TestMethod]
        public void FahrenheitBelowAbsoluteZero_Throws()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => KJMTTemperatureConverter.FahrenheitToCelsius(-500));
        }

        // ---- Propiedad de ida y vuelta (round-trip) con tolerancia
        [DataTestMethod]
        [DataRow(-40)]
        [DataRow(0)]
        [DataRow(20)]
        [DataRow(37)]
        [DataRow(100)]
        public void RoundTrip_Celsius(double c)
        {
            var f = KJMTTemperatureConverter.CelsiusToFahrenheit(c);
            var c2 = KJMTTemperatureConverter.FahrenheitToCelsius(f);
            Assert.AreEqual(R(c), R(c2), 0.01, "Round-trip C->F->C fuera de tolerancia.");
        }
    }
}