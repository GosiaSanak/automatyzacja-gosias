using System;
using Xunit;

namespace WebDriverTests
{
    public class LeaveCommentTest : IDisposable
    {
        private Comment ExampleComment = new Comment //tworzymy nowa klase comment, zeby w niej trzymac wszystkie propertiesy
        {
            Author = Guid.NewGuid().ToString(),
            Email = "some_mail@bleble.com",
            Text = Guid.NewGuid().ToString(),

        };

        public void Dispose()
        {
            WebBrowser.Driver.Quit();
        }

        //[Fact]
        public void When_user_is_not_logged_in_and_can_add_comment()
        {
            MainPage.GoTo();
            MainPage.AssertNotLoggedIn();
            MainPage.ShowNextPage();
            MainPage.LeaveComment(ExampleComment);
            MainPage.AssertCommentExist(ExampleComment);


        }

        [Fact]
        public void Adding_comment_to_another_comment()
        {
            MainPage.GoTo();
            MainPage.AssertNotLoggedIn();
            MainPage.SearchForComment();
            MainPage.ReplyToComment(ExampleComment);
            MainPage.AssertCommentExist(ExampleComment);

        }
   
    }

    
}
