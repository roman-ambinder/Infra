using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests
{
    [TestClass]
    public class OperationResultOfConstructionTests
    {
        [TestMethod]
        public void ValueTypeUseValueCtor_SuccessfulOperationResult()
        {
            //Arrange
            const bool expectedSuccessIndication = true;
            const string expcectedErrorMessage = null;
            const int expectedValue = 2;

            //Act
            var opRes = new OperationResultOf<int>(expectedValue);

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        [TestMethod]
        public void RefTypeUseValueCtor_SuccessfulOperationResult()
        {
            //Arrange
            const bool expectedSuccessIndication = true;
            const string expcectedErrorMessage = null;
            const string expectedValue = "Some Value";

            //Act
            var opRes = new OperationResultOf<string>(expectedValue);

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        [TestMethod]
        public void ValueTypeUseFullCtor_MatchingValuesOperationResultCreated()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const int expectedValue = 2;

            //Act
            var opRes = new OperationResultOf<int>(
                expectedSuccessIndication,
                expectedValue,
                expcectedErrorMessage);

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        [TestMethod]
        public void RefTypeUseFullCtor_MatchingValuesOperationResultCreated()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const string expectedValue = "2";

            //Act
            var opRes = new OperationResultOf<string>(
                expectedSuccessIndication,
                expectedValue,
                expcectedErrorMessage);

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        [TestMethod]
        public void ValueTypeUseExceptionCtor_FailedOperationResultWithMatchingMessageCreated()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const int expectedValue = default;

            //Act
            var opRes = new OperationResultOf<int>(
                new System.Exception(expcectedErrorMessage));

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        [TestMethod]
        public void RefTypeValueTypeUseExceptionCtor_FailedOperationResultWithMatchingMessageCreated()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            const string expectedValue = default;

            //Act
            var opRes = new OperationResultOf<string>(
                new System.Exception(expcectedErrorMessage));

            //Assert
            AssertValuesMatchExpected(opRes,
                expectedSuccessIndication,
                expcectedErrorMessage,
                expectedValue);
        }

        private static void AssertValuesMatchExpected<TValue>(
            OperationResultOf<TValue> opRes,
            bool expectedSuccessIndication,
            string expcectedErrorMessage,
            TValue expectedValue)
        {
            Assert.AreEqual(expectedValue, opRes.Value, $"Expected {nameof(opRes.Value)} '{opRes.Value}' to match '{expectedValue}'");
            Assert.AreEqual(expectedSuccessIndication, opRes.Success, $"Expected {nameof(opRes.Success)} '{opRes.Success}' to match '{expectedSuccessIndication}'");
            Assert.AreEqual(expcectedErrorMessage, opRes.ErrorMessage, $"Expected {nameof(opRes.ErrorMessage)} '{opRes.ErrorMessage}' to match '{expcectedErrorMessage}'");
        }
    }
}