using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests
{
    [TestClass]
    public class OpResExtensionsTests
    {
        [TestMethod]
        public void ValueTypeAsSuccessfullOpRes_MatchingOperationResReturned()
        {
            //Arrange 
            const int expectedValue = 0;

            //Act 
            var opRes = expectedValue.AsSuccessfullOpRes();

            //Assert
            Assert.AreEqual(expectedValue, opRes.Value);
            Assert.IsTrue(opRes.Success);
            Assert.IsNull(opRes.ErrorMessage);
        }

        [TestMethod]
        public void RefTypeAsSuccessfullOpRes_MatchingOperationResReturned()
        {
            //Arrange 
            const string expectedValue = "Some text";

            //Act 
            var opRes = expectedValue.AsSuccessfullOpRes();

            //Assert
            Assert.AreEqual(expectedValue, opRes.Value);
            Assert.IsTrue(opRes.Success);
            Assert.IsNull(opRes.ErrorMessage);
        }


        [TestMethod]
        public void FailedOpResAsFailedValueTypeOpRes_MatchingOperationResReturned()
        {
            //Arrange 
            var sourceFailedOpRes = new OperationResult(false, "Some error message");

            //Act 
            var opRes = sourceFailedOpRes.AsFailedOpResOf<int>();

            //Assert
            Assert.AreEqual(default, opRes.Value);
            Assert.IsFalse(opRes.Success);
            Assert.AreEqual(sourceFailedOpRes.ErrorMessage, opRes.ErrorMessage);
        }

        [TestMethod]
        public void FailedOpResAsFailedOpResOfRefType_MatchingOperationResReturned()
        {
            //Arrange 
            var sourceFailedOpRes = new OperationResult(false, "Some error message");

            //Act 
            var opRes = sourceFailedOpRes.AsFailedOpResOf<string>();

            //Assert
            Assert.AreEqual(default, opRes.Value);
            Assert.IsFalse(opRes.Success);
            Assert.AreEqual(sourceFailedOpRes.ErrorMessage, opRes.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageAsFailedOpResOfValueType_MatchingOperationResReturned()
        {            
            //Arrange 
            const string errorMessage = "Some error message";

            //Act 
            var opRes = errorMessage.AsFailedOpResOf<int>();

            //Assert
            Assert.AreEqual(default, opRes.Value);
            Assert.IsFalse(opRes.Success);
            Assert.AreEqual(errorMessage, opRes.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessageAsFailedOpResOfRefType_MatchingOperationResReturned()
        {
            //Arrange 
            const string errorMessage = "Some error message";

            //Act 
            var opRes = errorMessage.AsFailedOpResOf<string>();

            //Assert
            Assert.AreEqual(default, opRes.Value);
            Assert.IsFalse(opRes.Success);
            Assert.AreEqual(errorMessage, opRes.ErrorMessage);
        }

    }
}
