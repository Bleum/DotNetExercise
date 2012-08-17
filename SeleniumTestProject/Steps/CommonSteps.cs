using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestProject.Steps
{
    [Binding]
    public class CommonSteps: StepsBase
    {
        [BeforeScenario]
        public void InitSelenium()
        {
            driver = new FirefoxDriver();
            loginUrl = "http://localhost:26070/";
            //verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl(loginUrl);
        }

        [AfterScenario]
        public void CloseSelenium()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
