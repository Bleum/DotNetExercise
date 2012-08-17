using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SeleniumTestProject.Steps
{
    [Binding]
    public class EditandSaveSteps
    {
        [Given(@"I am logged into the form page")]
        public void GivenIAmLoggedIntoTheFormPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have edited the Employee Name ""(.*)"" to Polly Cruse""")]
        public void GivenIHaveEditedTheEmployeeNameToPollyCruse(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have edited the Employee Job Title ""(.*)"" to SQA""")]
        public void GivenIHaveEditedTheEmployeeJobTitleToSQA(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click Edit for item ""(.*)""")]
        public void WhenIClickEditForItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click ""(.*)"" for item ""Polly Picker")]
        public void WhenIClickForItemPollyPicker(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system opens the item on a new page")]
        public void ThenTheSystemOpensTheItemOnANewPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the new page allows ""(.*)"" and ""(.*)"" to be edited")]
        public void ThenTheNewPageAllowsAndToBeEdited(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I enter the Employee Name as ""(.*)""")]
        public void ThenIEnterTheEmployeeNameAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I enter the Job Title to be ""(.*)""")]
        public void ThenIEnterTheJobTitleToBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system saves the changes")]
        public void ThenTheSystemSavesTheChanges()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the page will go to the form home page")]
        public void ThenThePageWillGoToTheFormHomePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the data table will appear like this\.")]
        public void ThenTheDataTableWillAppearLikeThis_(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
