using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTests
{
    internal class WebBrowser
    {
        static WebBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage()
                .Window
                .Size = new System.Drawing.Size(Configuration.BrowserWidth,
                                                Configuration.BrowserHeight);
            Driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(Configuration.ImplicitWait);

        }
        public static IWebDriver Driver;

    }
}
