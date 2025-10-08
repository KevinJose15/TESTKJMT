using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJMT.Manipulaciones.UnitTest.xUnit
{
    public class KJMTStringManipulatorTest
    {
        // xUnit no requiere [TestClass]; el constructor no es necesario aquí.
        private readonly KJMTStringManipulator _manipulator = new KJMTStringManipulator();

        // *** Pruebas para ReverseString ***

        [Fact]
        public void ReverseString_SimpleWord_ReturnsReversedWord()
        {
            string input = "Hello";
            string expected = "olleH";

            string actual = _manipulator.ReverseString(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseString_EmptyString_ReturnsEmptyString()
        {
            string input = "";
            string expected = "";

            string actual = _manipulator.ReverseString(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReverseString_PhraseWithSpaces_ReturnsReversedPhrase()
        {
            string input = "a b c";
            string expected = "c b a";

            string actual = _manipulator.ReverseString(input);

            Assert.Equal(expected, actual);
        }

        // *** Pruebas para RemoveSpaces ***

        [Fact]
        public void RemoveSpaces_PhraseWithInternalSpaces_ReturnsConcatenatedString()
        {
            string input = "texto con espacios";
            string expected = "textoconespacios";

            string actual = _manipulator.RemoveSpaces(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveSpaces_StringWithLeadingAndTrailingSpaces_ReturnsCleanString()
        {
            string input = "  ejemplo  ";
            string expected = "ejemplo";

            string actual = _manipulator.RemoveSpaces(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveSpaces_StringWithNoSpaces_ReturnsSameString()
        {
            string input = "SinEspacios";
            string expected = "SinEspacios";

            string actual = _manipulator.RemoveSpaces(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveSpaces_OnlySpaces_ReturnsEmptyString()
        {
            string input = "   ";
            string expected = "";

            string actual = _manipulator.RemoveSpaces(input);

            Assert.Equal(expected, actual);
        }
    }
}
