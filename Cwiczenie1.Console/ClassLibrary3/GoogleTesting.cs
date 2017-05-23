using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace GoogleTesting
{
    public class GoogleTest
    {
        private ChromeDriver _driver;

        public GoogleTest() //constructor(bedziemy uzywac drivera chrome i bedzie pod nazwa _driver)
        {
            _driver = new ChromeDriver(); //stworz obiekt chrome driver, czyli wystartuj przegladarke
            _driver.Manage()
                .Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(5)); //jak sie opozni, to driver czeka 5 sekund, zanim krzyknie ze czegos nie znalazl
        }

        [Fact]
        public void Hello_test()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.FindElementById("lst-ib").SendKeys("code sprinters");
            _driver.FindElementById("_FZl").Click();
            var result = _driver.FindElementByXPath(@"//div/*/a[@href='http://agileszkolenia.pl/']");

            Assert.NotNull(result);
            Assert.Equal("Code Sprinters -", result.Text);

            _driver.Quit();
        }
    }
}
