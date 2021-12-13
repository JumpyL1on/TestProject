using System;
using System.Linq;
using NUnit.Framework;

namespace TestProject.Tests
{
    public class BaseTest
    {
        private static readonly Random Random = new Random();
        protected ApplicationManager ApplicationManager { get; set; }

        [SetUp]
        protected void SetUp()
        {
            ApplicationManager = ApplicationManager.GetInstance();
            ApplicationManager.NavigationHelper.GoToBaseUrl();
        }

        [TearDown]
        protected void TearDown()
        {
        }

        public static string GenerateRandomString(int length)
        {
            // ReSharper disable once StringLiteralTypo
            const string chars = "qQwWeErRtTyYuUiIoOpPaAsSdDfFgGhHjJkKlLzZxXcCvVbBnNmM";
            var arr = Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray();
            return new string(arr);
        }
    }
}