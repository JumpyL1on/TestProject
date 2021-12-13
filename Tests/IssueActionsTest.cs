using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject.Models;

namespace TestProject.Tests
{
    [TestFixture]
    public class IssueActionsTest : BaseAuthentication
    {
        [Test, Order(1), TestCaseSource(nameof(IssueDataFromXmlFile))]
        public void CreateIssueTest(IssueData issue)
        {
            ApplicationManager.NavigationHelper.GoToCreateIssuePage();
            ApplicationManager.IssueHelper.CreateIssue(issue);
            var createdIssue = ApplicationManager.IssueHelper.GetCreatedIssue();
            Assert.AreEqual(issue.Summary, createdIssue.Summary);
            Assert.AreEqual(issue.Description, createdIssue.Description);
        }

        [Test, Order(2), TestCaseSource(nameof(IssueDataFromXmlFile))]
        public void EditIssueTest(IssueData issue)
        {
            ApplicationManager.IssueHelper.OpenLastCreatedIssue();
            ApplicationManager.IssueHelper.EditIssue(issue);
            var editedIssue = ApplicationManager.IssueHelper.SelectLastCreatedIssue();
            Assert.AreEqual(issue.Summary, editedIssue.Summary);
            Assert.AreEqual(issue.Description, editedIssue.Description);
        }

        [Test, Order(3)]
        public void DeleteIssueTest()
        {
            ApplicationManager.IssueHelper.OpenLastCreatedIssue();
            ApplicationManager.IssueHelper.DeleteIssue();
            Assert.Throws<NoSuchElementException>(() => ApplicationManager.IssueHelper.OpenLastCreatedIssue());
        }

        private static List<IssueData> IssueDataFromXmlFile()
        {
            return (List<IssueData>) new XmlSerializer(typeof(List<IssueData>))
                .Deserialize(new StreamReader(Settings.IssuesXml));
        }
    }
}