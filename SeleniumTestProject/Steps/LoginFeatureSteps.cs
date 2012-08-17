using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTestProject
{
    [Binding]
    public class LoginFeatureSteps : StepsBase
    {
        [Given(@"I have entered ""(.*)"" into the Username field")]
        public void GivenIHaveEnteredIntoTheUsernameField(string p0)
        {
            InputUserName(p0);
        }

        [Given(@"I have entered ""(.*)"" into the Password field")]
        public void GivenIHaveEnteredIntoThePasswordField(string p0)
        {
            InputPassword(p0);
        }

        [Given(@"I have entered incorrectly ""(.*)"" into the Username field")]
        public void GivenIHaveEnteredIncorrectlyIntoTheUsernameField(string p0)
        {
            InputUserName(p0);
        }

        [Given(@"I have entered incorrectly ""(.*)"" into the Password field")]
        public void GivenIHaveEnteredIncorrectlyIntoThePasswordField(string p0)
        {
            InputPassword(p0);
        }

        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            ClickSignIn();
        }

        [Then(@"the system will allow me to login")]
        public void ThenTheSystemWillAllowMeToLogin()
        {
            // Nothing to check here
        }

        [Then(@"take me to the Form")]
        public void ThenTakeMeToTheForm()
        {
            Assert.AreEqual(driver.Title, "Index");
        }

        [Then(@"the system will deny me from login")]
        public void ThenTheSystemWillDenyMeFromLogin()
        {
            AssertLoginFail();
        }

        #region private helpers
        private static void ClickSignIn()
        {
            IWebElement SignInBtn = null;

            foreach (IWebElement element in driver.FindElements(By.TagName("input")))
            {
                if (element.GetAttribute("type") == "submit")
                {
                    SignInBtn = element;
                }
            }

            SignInBtn.Click();
        }

        private void InputPassword(string p0)
        {
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(p0);
        }

        private void InputUserName(string p0)
        {
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys(p0);
        }

        private static void AssertLoginFail()
        {
            Assert.AreEqual(
                driver.FindElement(By.ClassName("validation-summary-errors")).FindElement(By.TagName("span")).Text,
                "Login was unsuccessful. Please correct the errors and try again.");
        }
        #endregion
    }
}
