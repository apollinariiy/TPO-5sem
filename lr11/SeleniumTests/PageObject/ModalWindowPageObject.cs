using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PageObject
{
    public class ModalWindowPageObject
    {
        private IWebDriver driver;

        private readonly By _selectCityButton = By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div/div/div/div[2]/button[1]");
        
        private readonly By _cookieButton = By.XPath("//*[@id=\"app\"]/div[2]/div[7]/div[3]/button[1]");

        public ModalWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectCity() {
            driver.FindElement(_selectCityButton).Click();
        }
        public void SelectCookie()
        {
            driver.FindElement(_cookieButton).Click();
        }

    }
}
