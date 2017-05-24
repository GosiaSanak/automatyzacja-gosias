using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTests
{
    public class TestCasesV2: IDisposable
    {
        public readonly string tytulNotki;
        public static object NotatkaTestowa;

        public TestCasesV2()
        {
            string tytulNotki = "Test notatki Goska " + Guid.NewGuid();
        }

        [Fact]
        public void DODAWANIE_nowej_notki_jako_admin_i_WERYFIKACJA_tej_notki_jako_niezalogowany_uzytkownik()
        {

            Administrator.GoTo();
            Administrator.Login(Credentials.Valid);
            var url = Administrator.CreateNewPost(tytulNotki, NotatkaTestowa);
            Administrator.Logout();

            MainPage.GoTo(url);
            MainPage.AssertPostExist(tytulNotki);
        }

        public void Dispose()
        {
            Browser.GetBrowser().Quit();
        }
    }


    internal class Credentials
    {
        internal static object Valid;
    }

    internal class Browser
    {
        private static ChromeDriver _driver;

        static Browser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal static ChromeDriver GetBrowser()
        {
            return _driver;
        }
    }

    

    internal class Administrator
    {
        private static readonly ChromeDriver _driver = Browser.GetBrowser();
        private static object tytulNotki;
        private static object notatkaTestowa;

        

        internal static void GoTo()
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");
        }

        internal static void Login(object valid)
        {
            _driver.FindElementById("user_login").SendKeys("autotestdotnet@gmail.com");

            _driver.FindElementById("user_pass").SendKeys("codesprinters2016");

            _driver.FindElementById("wp-submit").Click();

        }

        internal static string CreateNewPost(object tytulNotki, object notatkaTestowa)
        {
            _driver.FindElementByClassName("page-title-action").Click();

            _driver.FindElementById("title").SendKeys(tytulNotki);

            _driver.FindElementById("content").SendKeys(notatkaTestowa);

            waitForElementPresent(By.CssSelector(".edit-slug"), 10);

            _driver.FindElementById("publish").Click();

            waitForElementPresent(By.Id("sample-permalink"), 10);

            return _driver.FindElementByXPath("(//span[@id='sample-permalink']/a)[1]").GetAttribute("href");
        }

        internal static void Logout()
        {
            _driver.FindElementByCssSelector(".avatar.avatar-32").Click();

            _driver.FindElementByCssSelector(".ab-sign-out").Click();
        }
    }

    internal class MainPage
    {
        private static readonly ChromeDriver _driver = Browser.GetBrowser();
        private static IEnumerable<object> tytulNotki;
        private static IEnumerable<object> tytulznalezionejnotki;

        internal static void GoTo(string permalink)
        {
            _driver.Navigate().GoToUrl(permalink);

            var tytulznalezionejnotki = _driver.FindElementByClassName("entry-title").Text;
        }

        internal static void AssertPostExist(string exampleTitle)
        {
            Assert.Equal(tytulNotki, tytulznalezionejnotki);
        }

    }
}
