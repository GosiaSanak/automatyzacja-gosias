using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebDriverTests
{
    public class TestCases : IDisposable

    {
        private ChromeDriver _driver; //definiuje co to jest _driver, poza konstruktorem

        public TestCases() //constructor
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void FixMe() //zeby test dzialal musi byc zawsze public void z atrybutem Fact
        {
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");
            // IWebElement firstPost = _driver.FindElementByClassName("post-title"); //IWebElement to konkretny rodzaj zmeinnej, mozna bylo var
            // String firstNoteTitle= firstPost.FindElement(By.TagName("a")).Text;   //String to konkretny rodzaj zmeinnej, mozna bylo var
            // jezeli notatka jest druga na blodu mozna to tez XPathem:(//header[@class = "post-title"][2]//a)[1] - znajdz pierwszy element o nazwie klasy...i tam drugi eleent dla ankora 'a'



            var posts = _driver.FindElementsByClassName("post-title"); //zamiast var mozna ReadOnlyCollection<IWedElement> - czyli kolekcje elementow typu IWeb
            var secondPost = posts[1];                                 //wtedy tutja tez zamiast var to IWebElement
            string firstNoteTitle = secondPost.FindElement(By.TagName("a")).Text;

            Assert.Equal("Vivamus aliquam feugiat", firstNoteTitle);
        }
    }
}
