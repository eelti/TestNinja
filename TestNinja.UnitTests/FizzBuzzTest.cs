using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void GetOutPut_InputIsDivisibleBy3and5_returnFizzBuzz()
        {
           var result = FizzBuzz.GetOutput(15);

            Assert.That(result,Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutPut_InputIsDivisibleBy3_returnFizz()
        {
           var result = FizzBuzz.GetOutput(3);

            Assert.That(result,Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutPut_InputIsDivisibleBy5_returnBuzz()
        {
           var result = FizzBuzz.GetOutput(5);

            Assert.That(result,Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutPut_InputIsNotDivisibleBy3Or5_returnFizzBuzz()
        {
           var result = FizzBuzz.GetOutput(1);

            Assert.That(result,Is.EqualTo("1"));
        }
    }
}