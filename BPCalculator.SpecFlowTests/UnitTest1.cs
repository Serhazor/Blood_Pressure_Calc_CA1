using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BPCalculator.SpecFlowTests.Steps
{
    [Binding]
    public class BloodPressureSteps
    {
        private readonly IWebDriver _driver;

        public BloodPressureSteps()
        {
            // Initialize the ChromeDriver
            _driver = new ChromeDriver();
        }

        [Given(@"I am on the blood pressure calculator page")]
        public void GivenIAmOnTheBloodPressureCalculatorPage()
        {
            // Navigate to the calculator page
            _driver.Navigate().GoToUrl("https://bpcalculatorca.azurewebsites.net/");
        }

        [When(@"I enter ""(.*)"" into the systolic field")]
        public void WhenIEnterIntoTheSystolicField(string systolicValue)
        {
            // Enter value into the systolic field
            var systolicField = _driver.FindElement(By.Id("BP_Systolic"));
            systolicField.Clear();
            systolicField.SendKeys(systolicValue);
        }

        [When(@"I enter ""(.*)"" into the diastolic field")]
        public void WhenIEnterIntoTheDiastolicField(string diastolicValue)
        {
            // Enter value into the diastolic field
            var diastolicField = _driver.FindElement(By.Id("BP_Diastolic"));
            diastolicField.Clear();
            diastolicField.SendKeys(diastolicValue);
        }

        [When(@"I press the submit button")]
        public void WhenIPressTheSubmitButton()
        {
            // Press the submit button
            var submitButton = _driver.FindElement(By.CssSelector("input[type='submit']"));
            submitButton.Click();
        }

        [Then(@"I should see the message ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string expectedMessage)
        {
            // Wait for the message to be visible and then assert
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var messageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[contains(text(), '{expectedMessage}')]")));

            Assert.AreEqual(expectedMessage, messageElement.Text);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            // Clean up WebDriver after each scenario
            _driver.Dispose();
        }
    }
}
