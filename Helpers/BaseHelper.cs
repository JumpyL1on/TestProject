using TestProject.Tests;

namespace TestProject.Helpers
{
    public class BaseHelper
    {
        protected ApplicationManager ApplicationManager { get; }

        protected BaseHelper(ApplicationManager applicationManager)
        {
            ApplicationManager = applicationManager;
        }
    }
}