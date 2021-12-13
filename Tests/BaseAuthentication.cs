using NUnit.Framework;
using TestProject.Models;

namespace TestProject.Tests
{
    public class BaseAuthentication : BaseTest
    {
        [SetUp]
        protected new void SetUp()
        {
            ApplicationManager = ApplicationManager.GetInstance();
            ApplicationManager.NavigationHelper.GoToBaseUrl();
            var user = new AccountData(Settings.Email, Settings.Password);
            ApplicationManager.AuthenticationHelper.Login(user);
        }

        [TearDown]
        protected new void TearDown()
        {
        }
    }
}