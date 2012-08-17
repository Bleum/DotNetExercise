using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTestProject
{
    [Binding]
    public class ListSteps : StepsBase
    {
        [Given(@"the link ""(.*)"" is avaliable")]
        public void GivenTheLinkIsAvaliable(string p0)
        {
            Assert.IsTrue(driver.FindElement(By.LinkText(p0)).Enabled);
        }
        
        [When(@"I have not pressed Search")]
        public void WhenIHaveNotPressedSearch()
        {
            // TODO: How could we know what we did not do?
        }
        
        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter ""(.*)"" in the Search Name field")]
        public void WhenIEnterInTheSearchNameField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"press search")]
        public void WhenPressSearch()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter ""(.*)"" in the Search Job field")]
        public void WhenIEnterInTheSearchJobField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the form lists (.*) items on the page")]
        public void ThenTheFormListsItemsOnThePage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"there are (.*) pages total")]
        public void ThenThereArePagesTotal(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it displays")]
        public void ThenItDisplays(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the form lists the next (.*) items on the next page")]
        public void ThenTheFormListsTheNextItemsOnTheNextPage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the form lists the previous (.*) items on the previous page")]
        public void ThenTheFormListsThePreviousItemsOnThePreviousPage(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the table displays only")]
        public void ThenTheTableDisplaysOnly(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the table displays only")]
        public void ThenTheTableDisplaysOnly()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
