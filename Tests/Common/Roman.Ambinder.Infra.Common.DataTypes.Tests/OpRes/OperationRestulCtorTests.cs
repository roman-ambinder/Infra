using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests
{
    [TestClass]
    public class OperationRestulCtorTests
    {
        [TestMethod]
        public void FullCtor_OperationWithMatchingValues()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";

            //Act
            var opRes = new OperationResult(
                success: expectedSuccessIndication,
                errorMessage: expcectedErrorMessage);

            //Assert
            Assert.AreEqual(expectedSuccessIndication, opRes.Success, $"Expected {nameof(opRes.Success)} '{opRes.Success}' to match '{expectedSuccessIndication}'");
            Assert.AreEqual(expcectedErrorMessage, opRes.ErrorMessage, $"Expected {nameof(opRes.ErrorMessage)} '{opRes.ErrorMessage}' to match '{expcectedErrorMessage}'");
        }

        [TestMethod]
        public void ExceptionCtor_FailedOperationResultWithMatchingErrorMessageCreated()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";

            //Act
            var opRes = new OperationResult(new Exception(expcectedErrorMessage));

            //Assert
            Assert.AreEqual(expectedSuccessIndication, opRes.Success, $"Expected {nameof(opRes.Success)} '{opRes.Success}' to match '{expectedSuccessIndication}'");
            Assert.AreEqual(expcectedErrorMessage, opRes.ErrorMessage, $"Expected {nameof(opRes.ErrorMessage)} '{opRes.ErrorMessage}' to match '{expcectedErrorMessage}'");
        }
    }
}