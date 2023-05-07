using System;
using AutomationExcercise.Helpers;
using AutomationExcercise.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationExcercise.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.loginLink);
        }
        
        [Given(@"user enters correct credentials")]
        public void GivenUserEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.loginEmail, TestConstants.Username);
            ut.EnterTextInElement(ap.loginPassword, TestConstants.Password);
        }
        
        [When(@"user submits login form")]
        public void WhenUserSubmitsLoginForm()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementIsDisplayed(hp.deleteAcc), "User is NOT logged in");
        }

        [Given(@"enters '(.*)' name and valid email address")]
        public void GivenEntersNameAndValidEmailAddress(string name)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.name, name);
            ut.EnterTextInElement(ap.signupEmail, ut.GenerateRandomEmail());
        }


        [Given(@"user clicks on SignUp button")]
        public void GivenUserClicksOnSignUpButton()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signupBtn);
        }

        [When(@"user fills in all required fields")]
        public void WhenUserFillsInAllRequiredFields()
        {
            SignUpPage sp = new SignUpPage(Driver);
            ut.EnterTextInElement(sp.password, TestConstants.Password);
            ut.EnterTextInElement(sp.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sp.lastName, TestConstants.LastName);
            ut.EnterTextInElement(sp.address, TestConstants.Address);
            ut.DropdownSelect(sp.country, TestConstants.Country);
            ut.EnterTextInElement(sp.state, TestConstants.State);
            ut.EnterTextInElement(sp.city, TestConstants.City);
            ut.EnterTextInElement(sp.zipcode, TestConstants.Zipcode);
            ut.EnterTextInElement(sp.mobile, TestConstants.Phone);
        }

        [When(@"submits the signup form")]
        public void WhenSubmitsTheSignupForm()
        {
            SignUpPage sp = new SignUpPage(Driver);
            Driver.FindElement(sp.form).Submit();
        }

        [Then(@"user will get '(.*)' success message")]
        public void ThenUserWillGetSuccessMessage(string message)
        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentInElement(message),"User did NOT get expected success message");
            ut.ClickOnElement(acp.continiueBtn);
        }
        [Given(@"user registers new account with '(.*)' name")]
        public void GivenUserRegistersNewAccountWithName(string name)
        {
            GivenUserOpensSignInPage();
            GivenEntersNameAndValidEmailAddress(name);
            GivenUserClicksOnSignUpButton();
            WhenUserFillsInAllRequiredFields();
            WhenSubmitsTheSignupForm();
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            ut.ClickOnElement(acp.continiueBtn);
        }

        [When(@"user selects option for deleting the account")]
        public void WhenUserSelectsOptionForDeletingTheAccount()
        {
             ut.ClickOnElement(hp.deleteAcc);
        }

        [Then(@"account will be deleted with '(.*)' message")]
        public void ThenAccountWillBeDeletedWithMessage(string message)
        {
            Assert.True(ut.TextPresentInElement(message), "Account is not deleted");
        }

    }
}
