using System;
using System.Xml;

namespace TestProject.Models
{
    public static class Settings
    {
        public static string BaseUrl { get; }
        public static string Email { get; }
        public static string Password { get; }
        public static string IssuesXml { get; }
        public static string LastCreatedIssue { get; private set; }
        public static string EdgeDriverDirectory { get; }
        private static string SettingsXml { get; } = @"C:\Users\yasch\RiderProjects\TestProject\Models\settings.xml";
        private static XmlDocument XmlDocument { get; } = new XmlDocument();

        static Settings()
        {
            if (!System.IO.File.Exists(SettingsXml))
                throw new Exception("Problem: settings file not found: " + SettingsXml);
            XmlDocument.Load(SettingsXml);
            BaseUrl = XmlDocument.DocumentElement?.SelectSingleNode("BaseUrl")?.InnerText;
            Email = XmlDocument.DocumentElement?.SelectSingleNode("Email")?.InnerText;
            Password = XmlDocument.DocumentElement?.SelectSingleNode("Password")?.InnerText;
            IssuesXml = XmlDocument.DocumentElement?.SelectSingleNode("IssuesXml")?.InnerText;
            LastCreatedIssue = XmlDocument.DocumentElement?.SelectSingleNode("LastCreatedIssue")?.InnerText;
            EdgeDriverDirectory = XmlDocument.DocumentElement?.SelectSingleNode("EdgeDriverDirectory")?.InnerText;
        }

        public static void UpdateLastIssue(string lastCreatedIssue)
        {
            LastCreatedIssue = lastCreatedIssue;
            if (XmlDocument.DocumentElement != null)
                // ReSharper disable once PossibleNullReferenceException
                XmlDocument.DocumentElement.SelectSingleNode("LastCreatedIssue").InnerText = lastCreatedIssue;
            XmlDocument.Save(SettingsXml);
        }
    }
}