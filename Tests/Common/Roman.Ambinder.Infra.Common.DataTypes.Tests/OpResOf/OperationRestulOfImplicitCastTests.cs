using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests
{
    [TestClass]
    public class OperationRestulOfImplicitCastTests
    {
        [TestMethod]
        public void SuccessfulValueTypeOpRes_ImplicitCast_MatchingExpected()
        {
            //Arrange
            const bool expectedSuccessIndication = true;
            const string expcectedErrorMessage = null;
            const int expectedValue = 2;
            var opRes = new OperationResultOf<int>(
               expectedSuccessIndication,
               expectedValue,
               expcectedErrorMessage);

            //Act
            bool actualSuccessIndication = opRes;
            int actualValue = opRes.Value;
            OperationResult opResNoValue = opRes;

            //Assert
            AssertAreEqual(opRes,
                expectedSuccessIndication,
                expectedValue,
                actualSuccessIndication,
                actualValue,
                opResNoValue);
        }

        [TestMethod]
        public void FailedValueTypeOpRes_ImplicitCast_MatchingExpected()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const int expectedValue = default;
            var opRes = new OperationResultOf<int>(
               expectedSuccessIndication,
               expectedValue,
               expcectedErrorMessage);

            //Act
            bool actualSuccessIndication = opRes;
            int actualValue = opRes.Value;
            OperationResult opResNoValue = opRes;

            //Assert
            AssertAreEqual(opRes,
                expectedSuccessIndication,
                expectedValue,
                actualSuccessIndication,
                actualValue,
                opResNoValue);
        }

        [TestMethod]
        public void SuccessfulRefTypeOpRes_ImplicitCast_MatchingExpected()
        {
            //Arrange
            const bool expectedSuccessIndication = true;
            const string expcectedErrorMessage = null;
            const string expectedValue = "2";
            var opRes = new OperationResultOf<string>(
               expectedSuccessIndication,
               expectedValue,
               expcectedErrorMessage);

            //Act
            bool actualSuccessIndication = opRes;
            string actualValue = opRes.Value;
            OperationResult opResNoValue = opRes;

            //Assert
            AssertAreEqual(opRes,
                expectedSuccessIndication,
                expectedValue,
                actualSuccessIndication,
                actualValue,
                opResNoValue);
        }

        [TestMethod]
        public void FailedRefTypeOpRes_ImplicitCast_MatchingExpected()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const string expectedValue = default;
            var opRes = new OperationResultOf<string>(
               expectedSuccessIndication,
               expectedValue,
               expcectedErrorMessage);

            //Act
            bool actualSuccessIndication = opRes;
            string actualValue = opRes.Value;
            OperationResult opResNoValue = opRes;

            //Assert
            AssertAreEqual(opRes,
                expectedSuccessIndication,
                expectedValue,
                actualSuccessIndication,
                actualValue,
                opResNoValue);
        }

        private static void AssertAreEqual<T>(
            OperationResultOf<T> opRes,
            bool expectedSuccessIndication,
            T expectedValue,
            bool actualSuccessIndication,
            T actualValue,
            OperationResult actualOpRes)
        {
            Assert.AreEqual(expectedSuccessIndication, actualSuccessIndication);
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(opRes.Success, actualOpRes.Success);
            Assert.AreEqual(opRes.ErrorMessage, actualOpRes.ErrorMessage);
        }
    }
}