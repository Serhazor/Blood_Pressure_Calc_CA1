using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BPCalculator.SeleniumTests
{
    [TestClass]
    public class BloodPressureWebTests
    {
        private IWebDriver driver;
        private string testUrl;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            testUrl = Environment.GetEnvironmentVariable("BPCALCULATOR_BASE_URL") ?? "https://bpcalculatorca.azurewebsites.net/";
            driver.Navigate().GoToUrl(testUrl);
        }

        [TestMethod]
        public void TestBloodPressureCategory()
        {
            IWebElement systolicInput = driver.FindElement(By.Id("BP_Systolic"));
            IWebElement diastolicInput = driver.FindElement(By.Id("BP_Diastolic"));
            IWebElement submitButton = driver.FindElement(By.XPath("//input[@value='Submit']"));

            systolicInput.Clear();
            diastolicInput.Clear();

            systolicInput.SendKeys("120");
            diastolicInput.SendKeys("80");
            submitButton.Click();

            IWebElement resultDiv = driver.FindElement(By.CssSelector("div.form-group:nth-child(4)"));
            Assert.IsTrue(resultDiv.Text.Contains("Ideal"), "The blood pressure should be classified as Ideal.");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
