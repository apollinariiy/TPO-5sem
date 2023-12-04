using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PageObject
{

    public class MainWindowPageObject
    {
        private IWebDriver driver;

        private readonly By _basketButton = By.XPath("//*[@id=\"header-top\"]/div[5]/div/div/div[3]/a/span");

        public MainWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToBasket() { 
        driver.FindElement(_basketButton).Click();
        }

        public CategoryWindowPageObject GoToCategory(string linkText) {
            IWebElement linkElement = driver.FindElement(By.XPath($"//a[contains(text(), '{linkText}')]"));
            linkElement.Click();
            return new CategoryWindowPageObject(driver);
        }

        ////*[@id="catalog"]/div[1]/div[3]/a
        /////*[@id="catalog"]/div[1]/div[2]/a
    }
}
