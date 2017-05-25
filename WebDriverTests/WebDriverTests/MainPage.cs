using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

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
            Assert.Throws<NoSuchElementException>(()=> Browser.FindElement(By.Id("wpadminbar")));

            //mozna to tez inaczej:
            // try
        }

        internal static void ShowNextPage()
        {
            var InfiniteHandle = (By.Id("infinite-handle"));
            var olderPosts = Browser.FindElement(InfiniteHandle);
            var button = olderPosts.FindElement(By.TagName("button"));
            button.Click();
            WaitForElementPresent(InfiniteHandle);
        }

     

        internal static void LeaveComment(Comment exampleComment)
        {
            var comments = Browser.FindElements(By.ClassName("comments-link"));
            var secondComment = comments[1];
            var a = secondComment.FindElement(By.TagName("a")); //najpierw trzeba poszukac atrybut zaczynajacy sie od nodu 'a'
            var leaveCommentUrl = a.GetAttribute("href"); //a pozniej wyciagnac z niego atrybut - link

            Browser.Navigate().GoToUrl(leaveCommentUrl);
        }

        internal static void AssertCommentExist(Comment exampleComment)
        {
            throw new NotImplementedException();
        }

        protected static void WaitForElementPresent(By by)
        {
            WebDriverWait wait = new WebDriverWait(Browser,TimeSpan.FromSeconds(Configuration.ImplicitWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}