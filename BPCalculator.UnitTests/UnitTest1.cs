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

        [TestMethod]
        public void Category_ShouldReturnLow_WhenPressureIsLow()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 80, Diastolic = 50 };

            // Act
            var result = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Low, result, "Blood pressure should be classified as Low.");
        }

        [TestMethod]
        public void Category_ShouldReturnPreHigh_WhenPressureIsPreHigh()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 130, Diastolic = 85 };

            // Act
            var result = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.PreHigh, result, "Blood pressure should be classified as Pre-High.");
        }

        [TestMethod]
        public void Category_ShouldReturnUnknown_WhenPressureIsOutOfRange()
        {
            // Arrange
            var bp = new BloodPressure { Systolic = 200, Diastolic = 110 }; // Example out of range values

            // Act
            var result = bp.Category;

            // Assert
            Assert.AreEqual(BPCategory.Unknown, result, "Blood pressure should be classified as Unknown for out of range values.");
        }

    }
}
