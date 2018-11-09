using System;
using Xunit;
using IOValidation.ConsoleImp;

namespace IOValidationTestProject
{
    public class ConsoleReaderTest
    {
        #region Start info
        ConsoleReader reader;
        public ConsoleReaderTest()
        {
            reader = new ConsoleReader();
        }
        #endregion

        #region GetDoubleNumber
        [Fact]
        public void GetDoubleNumber_WhenDouble_ReturnsTrue()
        {
            double expectedNumber = 10.6;
            Assert.Equal(expectedNumber, reader.GetDoubleNumber(expectedNumber.ToString()));
        }

        [Fact]
        public void GetDoubleNumber_WhenStringWithEmptyChars_ReturnsTrue()
        {
            double expectedNumber = 10.6;
            Assert.Equal(expectedNumber, reader.GetDoubleNumber(expectedNumber.ToString() + "\n\t   "));
        }

        [Fact]
        public void GetDoubleNumber_WhenWrongInput_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => reader.GetDoubleNumber("asdasdasd"));
        }
        #endregion

        #region GetIntNumber
        [Fact]
        public void GetIntNumber()
        {
            int expectedNumber = 10;
            Assert.Equal(expectedNumber, reader.GetIntNumber(expectedNumber.ToString()));
        }

        [Fact]
        public void GetIntNumber_WhenDouble_ReturnsArgumentException()
        {
            double expectedNumber = 10.6;
            Assert.Throws<ArgumentException>(() => reader.GetIntNumber(expectedNumber.ToString() + "\n\t   "));
        }

        [Fact]
        public void GetIntNumber_WhenWrongInput_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => reader.GetIntNumber("asdasdasd"));
        }
        #endregion

        #region GetNotEmptyString
        [Fact]
        public void GetNotEmptyString_WhenNotEmpty_ReturnsTrue()
        {
            string expected = "Not empty string";
            Assert.Equal(expected, reader.GetNotEmptyString(expected + "              \n\n\n"));
        }

        [Fact]
        public void GetNotEmptyString_WhenWhiteChars_ReturnsArgumentException()
        {
            string wrongInput = "\t  \n  \r\n";
            Assert.Throws<ArgumentException>(() => reader.GetNotEmptyString(wrongInput));
        }

        [Fact]
        public void GetNotEmptyString_WhenEmpty_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => reader.GetNotEmptyString(String.Empty));
        }
        #endregion

        #region GetNotNullChar
        [Fact]
        public void GetNotNullChar_WhenNotEmpty_ReturnsTrue()
        {
            char expected = 'a';
            string testString = expected + "   \n\t";
            Assert.Equal(expected, reader.GetNotNullChar(testString));
        }

        [Fact]
        public void GetNotNullChar_WhenNotOneChar_ReturnsArgumentException()
        {
            string testString = "asdasdasd";
            Assert.Throws<ArgumentException>(() =>  reader.GetNotNullChar(testString));
        }

        [Fact]
        public void GetNotNullChar_WhenEmpty_ReturnsArgumentException()
        {
            char emptyChar = ' ';
            Assert.Throws<ArgumentException>(() => reader.GetNotNullChar(emptyChar.ToString()));
        }
        #endregion

        #region GetBinary
       
        #endregion
    }
}
