using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestProject.Models;
using TestProject.Tests;

namespace TestProject.Helpers
{
    public class IssueHelper : BaseHelper
    {
        public IssueHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void CreateIssue(IssueData issue)
        {
            EnterSummary(issue.Summary);
            EnterDescription(issue.Description);
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"createIssueAction\"]")).Click();
            Thread.Sleep(4000);
            Settings.UpdateLastIssue(ApplicationManager.Driver
                .FindElement(By.CssSelector("*[data-test=\"issue-id-link\"]")).Text);
            Thread.Sleep(4000);
        }

        public void EditIssue(IssueData issue)
        {
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"yt-issue-edit\"]")).Click();
            Thread.Sleep(2000);
            EditSummary(issue.Summary);
            EditDescription(issue.Description);
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"applyChanges\"]")).Click();
            Thread.Sleep(8000);
        }

        public void DeleteIssue()
        {
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"yt-issue-delete\"]")).Click();
            Thread.Sleep(2000);
            ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"confirm-ok-button\"]")).Click();
            Thread.Sleep(8000);
        }

        public IssueData GetCreatedIssue()
        {
            var summary = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueSummary\"]")).Text;
            var description = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"wikiText\"]")).Text;
            return new IssueData(summary, description);
        }
        
        public void OpenLastCreatedIssue()
        {
            ApplicationManager.NavigationHelper.GoToIssuesPage();
            ApplicationManager.NavigationHelper.GoToIssuePage(Settings.LastCreatedIssue);
        }

        public IssueData SelectLastCreatedIssue()
        {
            var summary = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueSummary\"]")).Text;
            var description = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"wikiText\"]")).Text;
            return new IssueData(summary, description);
        }

        private void EnterSummary(string summary)
        {
            var issueSummary = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueSummary\"]"));
            issueSummary.Click();
            issueSummary.SendKeys(summary);
            Thread.Sleep(2000);
        }

        private void EditSummary(string summary)
        {
            var issueSummary = ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueSummary\"]"));
            issueSummary.Click();
            issueSummary.Clear();
            Thread.Sleep(2000);
            issueSummary.SendKeys(summary);
            Thread.Sleep(2000);
        }

        private void EnterDescription(string description)
        {
            var issueDescription =
                ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueDescription\"]"));
            issueDescription.Click();
            issueDescription.SendKeys(description);
            Thread.Sleep(2000);
        }

        private void EditDescription(string description)
        {
            var issueDescription =
                ApplicationManager.Driver.FindElement(By.CssSelector("*[data-test=\"issueDescription\"]"));
            issueDescription.Click();
            issueDescription.Clear();
            Thread.Sleep(2000);
            issueDescription.SendKeys(description);
            Thread.Sleep(2000);
        }
    }
}