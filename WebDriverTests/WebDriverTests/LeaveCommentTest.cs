using Xunit;

namespace WebDriverTests
{
    public class LeaveCommentTest
    {
        private Comment ExampleComment = new Comment //tworzymy nowa klase comment, zeby w niej trzymac wszystkie propertiesy
        {
            Name = "Selenium",
            Email = "some_mail@bleble.com",
            Text = "blebleble, chodzmy na kawe",

        };

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
