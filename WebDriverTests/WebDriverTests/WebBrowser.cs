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
            //Driver = new FirefoxDriver(); - to wystarczy wymienic tego drivera i test leci w innej przegladarce, ale trzeba miec ustawionego IWebDriver, jak na dole: public static IWebDriver Driver

            Driver.Manage()
                .Window
                .Size = new System.Drawing.Size(Configuration.BrowserWidth,
                                                Configuration.BrowserHeight);
            Driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(Configuration.ImplicitWait);

        }
        public static IWebDriver Driver; //Tu zamiast IWebDrivera mozna uzyc WebBrowsera, ale wedy trzeba to wszystko robic, jak w poprzednim tescie

    }
}
