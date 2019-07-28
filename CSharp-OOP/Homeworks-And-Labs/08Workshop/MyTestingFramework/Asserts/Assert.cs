namespace MyTestingFramework.Asserts
{
    using Exceptions;

    public static class Assert
    {
        public static bool AreEqual(int expectedResult, int actualResult)
        {
            if (expectedResult != actualResult)
            {
                throw new TestException($"Values are not the same! Actual: {actualResult}, Expected: {expectedResult}.");
            }

            return true;
        }
    }
}
