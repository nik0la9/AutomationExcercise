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

        private readonly ProductData productData;

        public ProductsSteps(ProductData productData)
        {
            this.productData = productData;
        }

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

        [Given(@"user opens products page")]
        public void GivenUserOpensProductsPage()
        {
            ut.ClickOnElement(hp.productsLink);
        }

        [Given(@"searches for '(.*)' products")]
        public void GivenSearchesForProducts(string searchMsg)
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.EnterTextInElement(pp.searchBox, TestConstants.Searchtext2);
        }

        [Given(@"opens first search result")]
        public void GivenOpensFirstSearchResult()
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.ClickOnElement(pp.viewProduct);
        }

        [When(@"user clicks on Add to Cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            ProductsDetailsPage pdp = new ProductsDetailsPage(Driver);
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
            ut.ClickOnElement(pdp.addtoCart);
        }

        [When(@"proceeds to the cart")]
        public void WhenProceedsToTheCart()
        {
            ProductsDetailsPage pdp = new ProductsDetailsPage(Driver);
            ut.ClickOnElement(pdp.addtoCart);
        }

        [Then(@"shopping cart will be displayed with expected product inside")]
        public void ThenShoppingCartWillBeDisplayedWithExpectedProductInside()
        {
            Assert.True(ut.TextPresentInElement(productData.ProductName), "Expected product is not in the cart");
        }

    }

}
