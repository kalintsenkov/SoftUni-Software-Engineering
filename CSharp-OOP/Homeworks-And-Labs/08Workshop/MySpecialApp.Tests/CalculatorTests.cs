namespace MySpecialApp.Tests
{
    using MyTestingFramework.Asserts;
    using MyTestingFramework.Attributes;

    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldSumSuccessfullyTwoValues()
        {
            // arrange
            var a = 10;
            var b = 20;
            var expectedResult = 30;

            // act
            var calculator = new Calculator();
            var actualResult = calculator.Sum(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShouldDivideSuccessfullyTwoValues()
        {
            // arrange
            var a = 10;
            var b = 10;
            var expectedResult = 1;

            // act
            var calculator = new Calculator();
            var actualResult = calculator.Divide(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
