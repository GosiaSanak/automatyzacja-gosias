using System;
using Xunit;

namespace WebDriverTests
{
    public class LeaveCommentTest : IDisposable
    {
        private Comment ExampleComment = new Comment //tworzymy nowa klase comment, zeby w niej trzymac wszystkie propertiesy
        {
            Name = "Selenium",
            Email = "some_mail@bleble.com",
            Text = "blebleble, chodzmy na kawe",

        };

        public void Dispose()
        {
            WebBrowser.Driver.Quit();
        }

        [Fact]
        public void When_user_is_not_logged_in_and_can_add_comment()
        {
            MainPage.GoTo();
            MainPage.AssertNotLoggedIn();
            MainPage.ShowNextPage();
            MainPage.LeaveComment(ExampleComment);
            MainPage.AssertCommentExist(ExampleComment);


        }
    }

    
}
