using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
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


        internal static void SearchForComment()
        {
            var comment = Browser.FindElement(By.XPath("(//*[@class='comments-link']/a)[last()]"));
            var leaveCommentText = comment.Text;
            while (leaveCommentText == "Leave a comment") 
            {
                ShowNextPage();
                comment = Browser.FindElement(By.XPath("(//*[@class='comments-link']/a)[last()]"));
                leaveCommentText = comment.Text;
            }
        }

        internal static void ReplyToComment(Comment exampleComment)
        {

            Browser.FindElement(By.XPath("(//*[@class='comments-link']/a)[last()]")).Click();
            Browser.FindElement(By.XPath("(//*[@class='reply']/a)")).Click();


            var commentBox = Browser.FindElement(By.Id("comment"));
            commentBox.Click();
            commentBox.SendKeys(exampleComment.Text);

            var mailField = Browser.FindElement(By.Id("email"));
            mailField.SendKeys(exampleComment.Email);

            var authorField = Browser.FindElement(By.Id("author"));
            authorField.SendKeys(exampleComment.Author);

            var submitElement = Browser.FindElement(By.Id("comment-submit"));
            submitElement.Click();
        }

        internal static void LeaveComment(Comment exampleComment)
        {
            var comments = Browser.FindElements(By.ClassName("comments-link"));
            var secondComment = comments[1];
            var a = secondComment.FindElement(By.TagName("a")); //najpierw trzeba poszukac atrybut zaczynajacy sie od nodu 'a'
            var leaveCommentUrl = a.GetAttribute("href"); //a pozniej wyciagnac z niego atrybut - link

            Browser.Navigate().GoToUrl(leaveCommentUrl);

            var commentBox = Browser.FindElement(By.Id("comment"));
            commentBox.Click();
            commentBox.SendKeys(exampleComment.Text);

            var mailField = Browser.FindElement(By.Id("email"));
            mailField.SendKeys(exampleComment.Email);

            var authorField = Browser.FindElement(By.Id("author"));
            authorField.SendKeys(exampleComment.Author);

            var submitElement = Browser.FindElement(By.Id("comment-submit"));
            submitElement.Click();
          
        }

        internal static void AssertCommentExist(Comment exampleComment)
        {

            var comments = Browser.FindElements(By.CssSelector(".comment-body"));
            var comment = comments.Single(c =>

                c.FindElement(By.TagName("cite")).Text == exampleComment.Author
                &&
                c.FindElement(By.TagName("p")).Text == exampleComment.Text
                );

            Assert.NotNull(comment);

            // mozna to tak alternatywnie zrobic, ale trzeba okreslic author i commentText na stronie"
            // string author = 
            //string commentText = 

           // Assert.Equal(exampleComment.Author, author);
           // Assert.Equal(exampleComment.Text, commentText);
        }

        protected static void WaitForElementPresent(By by)
        {
            WebDriverWait wait = new WebDriverWait(Browser,TimeSpan.FromSeconds(Configuration.ImplicitWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}