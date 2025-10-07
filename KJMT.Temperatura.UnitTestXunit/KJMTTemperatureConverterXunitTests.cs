using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTKJMT;

namespace KJMT.Temperatura.UnitTestXunit
{
    public class KJMTTemperatureConverterXunitTests
    {
        private static double R(double v) => Math.Round(v, 2);

        [Theory]
        [InlineData(0, 32)]
        [InlineData(100, 212)]
        [InlineData(-40, -40)]
        [InlineData(37, 98.6)]
        public void CelsiusToFahrenheit_OK(double c, double expectedF)
        {
            var actual = R(KJMTTemperatureConverter.CelsiusToFahrenheit(c));
            AssertInDelta(expectedF, actual, 0.01);
        }

        [Theory]
        [InlineData(32, 0)]
        [InlineData(212, 100)]
        [InlineData(-40, -40)]
        [InlineData(98.6, 37)]
        public void FahrenheitToCelsius_OK(double f, double expectedC)
        {
            var actual = R(KJMTTemperatureConverter.FahrenheitToCelsius(f));
            AssertInDelta(expectedC, actual, 0.01);
        }

        [Fact]
        public void CelsiusBelowAbsoluteZero_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                KJMTTemperatureConverter.CelsiusToFahrenheit(-300));
        }

        [Fact]
        public void FahrenheitBelowAbsoluteZero_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                KJMTTemperatureConverter.FahrenheitToCelsius(-500));
        }

        [Theory]
        [InlineData(-40)]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(37)]
        [InlineData(100)]
        public void RoundTrip_Celsius(double c)
        {
            var f = KJMTTemperatureConverter.CelsiusToFahrenheit(c);
            var c2 = KJMTTemperatureConverter.FahrenheitToCelsius(f);
            AssertInDelta(R(c), R(c2), 0.01);
        }

        private static void AssertInDelta(double expected, double actual, double delta)
        {
            var diff = Math.Abs(expected - actual);
            Assert.True(diff <= delta, $"Esperado {expected} ±{delta}, actual {actual} (diff {diff}).");
        }

    }
}
