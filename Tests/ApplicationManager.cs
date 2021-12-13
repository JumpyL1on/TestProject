using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using TestProject.Helpers;
using TestProject.Models;

namespace TestProject.Tests
{
    public class ApplicationManager
    {
        public IWebDriver Driver { get; }
        public NavigationHelper NavigationHelper { get; }
        public AuthenticationHelper AuthenticationHelper { get; }
        public IssueHelper IssueHelper { get; }

        private static ThreadLocal<ApplicationManager> ThreadLocalApplicationManager { get; } =
            new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            Driver = new EdgeDriver(Settings.EdgeDriverDirectory);
            Driver.Manage().Window.Maximize();
            NavigationHelper = new NavigationHelper(this, Settings.BaseUrl);
            AuthenticationHelper = new AuthenticationHelper(this);
            IssueHelper = new IssueHelper(this);
        }

        ~ApplicationManager()
        {
            Driver.Quit();
        }

        public static ApplicationManager GetInstance()
        {
            if (ThreadLocalApplicationManager.IsValueCreated)
                return ThreadLocalApplicationManager.Value;
            var newInstance = new ApplicationManager();
            ThreadLocalApplicationManager.Value = newInstance;
            return ThreadLocalApplicationManager.Value;
        }
    }
}