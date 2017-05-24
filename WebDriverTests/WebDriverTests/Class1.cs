using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

        //[Fact]
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
        // gogawanie nowej notki jako admin i weryfikacja tej notki

        private void waitForElementPresent(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        // DODAWANIE nowej notki jako admin i weryfikacja tej notki
        [Fact]
        public void AddNote()
        {
            string tytulNotki = "Test notatki Goska " + Guid.NewGuid();

            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/wp-admin/");

            _driver.FindElementById("user_login").SendKeys("autotestdotnet@gmail.com");

            _driver.FindElementById("user_pass").SendKeys("codesprinters2016");

            _driver.FindElementById("wp-submit").Click();

            _driver.FindElementsByClassName("wp-menu-name")[2].Click(); //mozna tez szukac XPathem po tekscie na stronie: //div[Text()='...')

            _driver.FindElementByClassName("page-title-action").Click();

            _driver.FindElementById("title").SendKeys(tytulNotki);

            _driver.FindElementById("content").SendKeys("Notatka testowa");

            waitForElementPresent(By.CssSelector(".edit-slug"), 10);

            _driver.FindElementById("publish").Click();

            waitForElementPresent(By.Id("sample-permalink"), 10);

            var permalink =_driver.FindElementByXPath("(//span[@id='sample-permalink']/a)[1]").GetAttribute("href");

            _driver.FindElementByCssSelector(".avatar.avatar-32").Click();

            _driver.FindElementByCssSelector(".ab-sign-out").Click();
            
            _driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/");

            var tytulznalezionejnotki = _driver.FindElementByXPath("//a[@href='" + permalink + "']").Text;


            Assert.Equal(tytulNotki, tytulznalezionejnotki);




            // Metoda wait for element present:
            //private void waitForElementPresent(By by, int seconds)
            //{
            //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            //   wait.Until(ExpectedConditions.ElementToBeClickable(by));
            //}
        }
    }
}
