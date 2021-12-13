using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Models;

namespace TestProject.Tests
{
    [TestFixture]
    public class AuthenticationTest : BaseTest
    {
        [Test, Order(2)]
        public void LoginWithValidDataTest()
        {
            var user = new AccountData(Settings.Email, Settings.Password);
            ApplicationManager.AuthenticationHelper.Login(user);
            Assert.DoesNotThrow(() => ApplicationManager.Driver.FindElement(By.CssSelector(".avatar_360")));
        }

        [Test, Order(1)]
        public void LoginWithInValidDataTest()
        {
            var user = new AccountData("wrongEmail", "wrongPassword");
            ApplicationManager.AuthenticationHelper.Login(user);
            Assert.DoesNotThrow(() =>
                ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")));
        }

        [Test, Order(3)]
        public void LogoutTest()
        {
            ApplicationManager.AuthenticationHelper.Logout();
            Assert.DoesNotThrow(() =>
                ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")));
        }
    }
}