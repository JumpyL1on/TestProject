using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Xml.Serialization;
using TestProject.Models;
using TestProject.Tests;

namespace Generator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var type = args[0];
            var count = int.Parse(args[1]);
            var file = args[2];
            var format = args[3];
            if (type == "issues")
                GenerateForIssues(count, file, format);
            else
                Console.WriteLine("Unrecognized type of data: " + type);
        }

        private static void GenerateForIssues(int count, string filename, string format)
        {
            var issues = new IssueData[count];
            for (var i = 0; i < count; i++)
            {
                var summary = BaseTest.GenerateRandomString(20);
                var description = BaseTest.GenerateRandomString(20);
                var issue = new IssueData(summary, description);
                issues[i] = issue;
            }

            using var writer = new StreamWriter(filename);
            if (format == "xml")
                WriteIssuesToXmlFile(issues, writer);
            else
                Console.WriteLine("Unrecognized format: " + format);
            writer.Close();
        }

        private static void WriteIssuesToXmlFile(IssueData[] issues, StreamWriter writer)
        {
            if (issues == null) 
                throw new ArgumentNullException(nameof(issues));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            new XmlSerializer(typeof(IssueData[])).Serialize(writer, issues);
        }
    }
}