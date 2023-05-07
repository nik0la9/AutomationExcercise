using System;
using AutomationExcercise.Helpers;
using AutomationExcercise.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationExcercise.Steps
{
    [Binding]
    public class ContactUsSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            ut.ClickOnElement(hp.contactLink);
        }
        
        [When(@"user enters all required fields")]
        public void WhenUserEntersAllRequiredFields()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.EnterTextInElement(cup.name, TestConstants.FirstName + " " + TestConstants.LastName);
            ut.EnterTextInElement(cup.email, TestConstants.Username);
            ut.EnterTextInElement(cup.subject, TestConstants.Subject);
            ut.EnterTextInElement(cup.message, TestConstants.Message);
            string path = @"C:\Users\Nikola\Downloads\Product Support Engineer Cleverbit.pdf";
            Driver.FindElement(cup.uploadBtn).SendKeys(path);
        }
        
        [When(@"submits contact us form")]
        public void WhenSubmitsContactUsForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            //ut.ClickOnElement(cup.submit);
            Driver.FindElement(cup.form).Submit();
        }
        
        [When(@"confirms the prompt message")]
        public void WhenConfirmsThePromptMessage()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
        
        [Then(@"user will recieve '(.*)' message")]
        public void ThenUserWillRecieveMessage(string successMessage)
        {
            Assert.True(ut.TextPresentInElement(successMessage), "user's message was NOT successfully sent via contact us form");
        }
    }
}
