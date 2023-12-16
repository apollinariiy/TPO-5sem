using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                var options = new OpenQA.Selenium.Chrome.ChromeOptions();
                options.BinaryLocation = @"C:\Users\user\AppData\Local\Google\Chrome\Application\chrome.exe";
                driver = new ChromeDriver("C:\\webdriver\\chromedriver-win64", options);
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
