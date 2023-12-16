using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;

namespace BPCalculator.UnitTests
{
    [TestClass]
    public class BloodPressureTests
    {
        [TestMethod]
        public void Category_ShouldReturnIdeal_WhenPressureIsWithinIdealRange()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 115, Diastolic = 75 };

            // Act
            var result = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, result, "Blood pressure should be classified as Ideal.");
        }

        [TestMethod]
        public void Category_ShouldReturnHigh_WhenPressureIsHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 160, Diastolic = 95 };

            // Act
            var result = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.High, result, "Blood pressure should be classified as High.");
        }

        // Additional tests for Low, PreHigh, and Unknown categories
    }
}
