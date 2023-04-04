using System;
using AutomationExcercise.Helpers;
using AutomationExcercise.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationExcercise.Steps
{
    [Binding]
    public class ProductsSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opened products page")]
        public void GivenUserOpenedProductsPage()
        {
            ut.ClickOnElement(hp.productsLink);
        }
        
        [When(@"user click on search box")]
        public void WhenUserClickOnSearchBox()
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.ClickOnElement(pp.searchBox);
        }
        
        [When(@"type in it ""(.*)""")]
        public void WhenTypeInIt(string searchMsg)
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.EnterTextInElement(pp.searchBox, TestConstants.Searchtext);
        }
        
        [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.ClickOnElement(pp.searchBtn);
        }
        
        [Then(@"searched items will be listed and message ""(.*)"" will appear")]
        public void ThenSearchedItemsWillBeListerAndMessageWillAppear(string searchedMessage)
        {
            Assert.True(ut.TextPresentInElement(searchedMessage), "searched messaged is not displayed");
        }
    }
}
