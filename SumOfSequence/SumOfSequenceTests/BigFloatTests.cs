using NUnit.Framework;
using SumOfSequence;

namespace SumOfSequenceTests
{
    public class BigFloatTests
    {
        BigFloat firstTestFloat;
        BigFloat secondTestFloat;
        BigFloat result;

        [SetUp]
        public void Init()
        {
            firstTestFloat = new BigFloat("0.12e+1");
            secondTestFloat = new BigFloat("0.12e+1");
            result = new BigFloat();
        }

        [Category("Parse")]
		[TestCase("1.0e1", "1.0e1")]
		[TestCase("1.0e+1", "1.0e+1")]
		[TestCase("1.0e-1", "1.0e-1")]
        public void Input_Number_Test(string input, string expected)
        {
            firstTestFloat = new BigFloat(input);
            result = new BigFloat(expected);
            Assert.That(firstTestFloat, Is.EqualTo(result));
        }

        [Category("Parse")]
        [TestCase(" 1.0e+1", "1.0e+1")]
        [TestCase("1.0e-1 ", "1.0e-1")]
        [TestCase("     1.0e-1      ", "1.0e-1")]
        public void Input_Number_With_Space_Test(string input, string expected)
        {
            firstTestFloat = new BigFloat(input);
            result = new BigFloat(expected);
            Assert.That(firstTestFloat, Is.EqualTo(result));
        }

        [Category("Format")]
        [TestCase("1.11", "1.11e+0")]
        [TestCase("11.11", "1.111e+1")]
        [TestCase("0.011", "1.1e-2")]
        [TestCase("11111.11", "1.111111e+4")]
        [TestCase("0.00011", "1.1e-4")]
        [TestCase("1.000", "1.0e+0")]
        [TestCase("1.100", "1.1e+0")]
        public void From_Float_To_Exponential_Test(string input, string expected)
        {
            Assert.That(BigFloat.ToExponentialFormat(input), Is.EqualTo(expected));
        }

        [Category("Format")]
        [TestCase("0.12e+1", "1.2")]
        [TestCase("0.12e-1", "0.012")]
        [TestCase("0.12e+4", "1200.0")]
        [TestCase("0.12e-4", "0.000012")]
        [TestCase("12.12e-2", "0.1212")]
        [TestCase("1.12e-2", "0.0112")]
        [TestCase("12.12e-3", "0.01212")]
        [TestCase("133.12e-3", "0.13312")]
        [TestCase("133.12e+3", "133120.0")]
        [TestCase("12.12e3", "12120.0")]
        [TestCase("123.2e-2", "1.232")]
        [TestCase("0.02e-2", "0.0002")]
        [TestCase("0.0002e-2", "0.000002")]
        [TestCase("0.2e-2", "0.002")]
        public void From_Exponential_To_Float_Test(string input, string expected)
        {
            firstTestFloat = new BigFloat(input);
            result = new BigFloat(BigFloat.ToExponentialFormat(expected));
            Assert.That(firstTestFloat, Is.EqualTo(result));

        }

        [Category("Format")]
        [TestCase("111.1234567890123456789012345678901234567890123", "1.111234567890123456789012345678901234567e+2")]
        [TestCase("0.00011234567890123456789012345678901234567890123", "1.123456789012345678901234567890123456789e-4")]
        public void From_Float_To_Exponential_Mantissa_Cut_Test(string input, string expected)
        {
            Assert.That(BigFloat.ToExponentialFormat(input), Is.EqualTo(expected));
        }

        [Category("Add")]
        [TestCase("12.2e+2", "12.32e-1", "1.221232e+3")]
        [TestCase("0.12e-2", "0.12e-2", "2.4e-3")]
        [TestCase("1.1e1", "1.1e+1", "2.2e+1")]
        [TestCase("1.1e1", "1.1e-1", "1.111e+1")]
        [TestCase("1.1e1", "1.1e1", "2.2e+1")]
        [TestCase("0.000e+0", "1.1e+1", "1.1e+1")]
        [TestCase("0.000e+0", "0.0e+0", "0.000e+0")]
        [TestCase("1.999e+0", "1.001e+0", "3.0e+0")]
        [TestCase("1.18e+1", "1.12e+1", "2.3e+1")]
        [TestCase("1.19e+0", "1.11e+0", "2.3e+0")]
        [TestCase("1.91e+1", "1.11e+1", "3.02e+1")]
        [TestCase("0.12e+1", "0.12e-1", "1.212e+0")]
        [TestCase("0.12e+1", "0.12e+1", "2.4e+0")]
        [TestCase("0.12e-1", "0.12e-1", "2.4e-2")]
        public void Add_Numbers_Test(string firstInput, string secondInput, string expected)
        {
            firstTestFloat = new BigFloat(firstInput);
            secondTestFloat = new BigFloat(secondInput);
            result = new BigFloat(expected);
            Assert.That(firstTestFloat + secondTestFloat, Is.EqualTo(result));
        }

    }
}
