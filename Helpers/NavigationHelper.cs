using System.Threading;
using OpenQA.Selenium;
using TestProject.Tests;

namespace TestProject.Helpers
{
    public class NavigationHelper : BaseHelper
    {
        private string BaseUrl { get; }

        public NavigationHelper(ApplicationManager applicationManager, string baseUrl) : base(applicationManager)
        {
            BaseUrl = baseUrl;
        }

        public void GoToBaseUrl()
        {
            ApplicationManager.Driver.Navigate().GoToUrl(BaseUrl);
            Thread.Sleep(8000);
        }

        public void GoToLoginPage()
        {
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"ring-header-login-button\"]")).Click();
            Thread.Sleep(8000);
        }

        public void GoToCreateIssuePage()
        {
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"createIssueButton\"]")).Click();
            Thread.Sleep(8000);
        }

        public void GoToIssuesPage()
        {
            ApplicationManager.Driver.FindElement(By.LinkText("Issues")).Click();
            Thread.Sleep(8000);
        }

        public void GoToIssuePage(string issueName)
        {
            ApplicationManager.Driver.FindElement(By.LinkText(issueName)).Click();
            Thread.Sleep(8000);
        }
    }
}