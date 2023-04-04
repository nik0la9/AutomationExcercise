﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExcercise.Pages
{
    class ProductsPage
    {
        readonly IWebDriver _driver;
        public By productsPage = By.Id("advertisement");
        public By searchBox = By.Name("search");
        public By searchBtn = By.ClassName("btn-lg");


        public ProductsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(productsPage));
        }
    }
}
