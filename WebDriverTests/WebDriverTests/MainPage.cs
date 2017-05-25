using OpenQA.Selenium;
using System;

namespace WebDriverTests
{
    internal class MainPage
    {
        public static IWebDriver Browser = WebBrowser.Driver; //typu IWebBrowser, typu Browser

        internal static void GoTo()
        {
            Browser.Navigate().GoToUrl(Configuration.BaseUrl); //wyciagnelismy url na zewntrz do osobnej klasy
        }

        internal static void AssertNotLoggedIn()
        {
            throw new NotImplementedException();
        }

        internal static void ShowNextPage()
        {
            throw new NotImplementedException();
        }

        internal static void LeaveComment(Comment exampleComment)
        {
            throw new NotImplementedException();
        }

        internal static void AssertCommentExist(Comment exampleComment)
        {
            throw new NotImplementedException();
        }
    }
}