using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roman.Ambinder.Infra.Common.DataTypes.Tests.NotNull
{
    [TestClass]
    public class NotNullGuardTests
    {
        [TestMethod]
        public void NullValue_UseNoReturnValue_NullActionExectued()
        {
            //Arrange
            NotNullGuard<string> target = null;

            //Act  + Assert
            target.Use(usageInfNotNull: value => Assert.Fail(),
                actionIfNull: () => Assert.IsTrue(true));
        }

        [TestMethod]
        public void NotNullValue_UseNoReturnValue_NotNullValueActionExectued()
        {
            //Arrange
            const string expectedValue = "Some value";
            NotNullGuard<string> target = expectedValue;

            //Act  + Assert
            target.Use(usageInfNotNull: value =>
            {
                Assert.IsTrue(true);
                Assert.AreEqual(expectedValue, value);
            }, actionIfNull: () => Assert.Fail());
        }

        [TestMethod]
        public void NullValue_UseWithReturnValue_NullActionExectued()
        {
            //Arrange
            NotNullGuard<string> target = null;

            //Act  + Assert
            string value = target.Use(usageInfNotNull: value =>
            {
                Assert.Fail();
                return value;
            }, actionIfNull: () => Assert.IsTrue(true));
        }

        [TestMethod]
        public void NotNullValue_UseWithReturnValue_NotNullActionExectued()
        {
            //Arrange
            const string expectedValue = "Some value";
            NotNullGuard<string> target = expectedValue;

            //Act  + Assert
            target.Use(usageInfNotNull: value =>
            {
                Assert.IsTrue(true);
                Assert.AreEqual(expectedValue, value);
                return value;
            }, actionIfNull: () => Assert.Fail());
        }
    }
}