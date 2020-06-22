using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests
{
    [TestClass]
    public class OperationResultImplicitCastTests
    {
        [TestMethod] 
        public void FailedOpRes_ImplicitCast_ExpectedValues()
        {
            //Arrange
            const bool expectedSuccessIndication = false;
            const string expcectedErrorMessage = "Some error message";
            var opRes = new OperationResult(
                success: expectedSuccessIndication,
                errorMessage: expcectedErrorMessage);

            //Act
            bool success = opRes;

            //Assert
            Assert.AreEqual(expectedSuccessIndication, success);
        }

        [TestMethod]
        public void SuccessfulOpRes_ImplicitCast_ExpectedValues()
        {
            //Arrange
            const bool expectedSuccessIndication = true;
            const string expcectedErrorMessage = null;
            var opRes = new OperationResult(
                success: expectedSuccessIndication,
                errorMessage: expcectedErrorMessage);

            //Act
            bool success = opRes;

            //Assert
            Assert.AreEqual(expectedSuccessIndication, success);
        }
    }
}