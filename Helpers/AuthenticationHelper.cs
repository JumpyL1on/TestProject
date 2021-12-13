using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using TestProject.Models;
using TestProject.Tests;

namespace TestProject.Helpers
{
    public class AuthenticationHelper : BaseHelper
    {
        public AuthenticationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Email))
                    return;
                Logout();
            }

            ApplicationManager.NavigationHelper.GoToLoginPage();
            EnterEmail(user.Email);
            EnterPassword(user.Password);
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")).Click();
            Thread.Sleep(8000);
        }

        public void Logout()
        {
            ApplicationManager.Driver.FindElement(By.CssSelector(".avatar_360")).Click();
            Thread.Sleep(2000);
            ApplicationManager.Driver
                .FindElements(By.CssSelector("*[data-test=\"ring-link ring-list-link ring-list-item\"]"))
                .LastOrDefault()?
                .Click();
            Thread.Sleep(8000);
        }

        private bool IsLoggedIn()
        {
            try
            {
                ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"ring-header-login-button\"]"));
            }
            catch (NoSuchElementException)
            {
                return true;
            }

            return false;
        }

        private bool IsLoggedIn(string email)
        {
            /*ApplicationManager.Driver.FindElement(By.CssSelector(".avatar_360")).Click();
            Thread.Sleep(2000);
            ApplicationManager.Driver
                .FindElement(By.CssSelector("*[data-test=\"ring-link ring-list-link ring-list-item\"]"))
                .Click();
            Thread.Sleep(6000);
            return ApplicationManager.Driver
                .FindElement(By.CssSelector("*[data-test=\"userProfileEmail\"]")).Text == email;*/
            return true;
        }

        private void EnterEmail(string email)
        {
            var element = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"username-field\"]"));
            element.Clear();
            element.SendKeys(email);
            Thread.Sleep(2000);
        }

        private void EnterPassword(string password)
        {
            var element = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"password-field\"]"));
            element.Clear();
            element.SendKeys(password);
            Thread.Sleep(2000);
        }
    }
}