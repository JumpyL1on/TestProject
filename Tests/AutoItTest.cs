using System.Threading;
using AutoIt;
using NUnit.Framework;

namespace TestProject.Tests
{
    [TestFixture]
    public class AutoItTest
    {
        [SetUp]
        protected void SetUp()
        {
        }

        [Test]
        public void CreateAutoItTxtTest()
        {
            AutoItX.Run(@"notepad.exe", @"C:\Windows\System32", AutoItX.SW_SHOW);
            AutoItX.WinWaitActive("[CLASS:Notepad]");
            AutoItX.Send("Hello from Notepad.{ENTER}1 2 3 4 5 6 7 8 9 10");
            Thread.Sleep(2000);
            AutoItX.WinClose("[CLASS:Notepad]");
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");
            AutoItX.WinWaitActive("[CLASS:#32770]");
            AutoItX.Send("autoit.txt");
            Thread.Sleep(2000);
            AutoItX.Send("{TAB}{ENTER}");
            Thread.Sleep(2000);
        }
        
        [Test]
        public void OpenAutoItTxtTest()
        {
            AutoItX.Run(@"notepad.exe", @"C:\Windows\System32", AutoItX.SW_SHOW);
            AutoItX.WinWaitActive("[CLASS:Notepad]");
            AutoItX.Send("^o");
            Thread.Sleep(2000);
            AutoItX.Send("autoit.txt");
            Thread.Sleep(2000);
            AutoItX.Send("{TAB}{TAB}{TAB}{ENTER}");
            Thread.Sleep(2000);
            AutoItX.WinClose("[CLASS:Notepad]");
        }


        [TearDown]
        protected void TearDown()
        {
        }
    }
}