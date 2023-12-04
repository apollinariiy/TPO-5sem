using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PageObject
{

    public class BasketWindowPageObject
    {
        private IWebDriver driver;
        private readonly By _countProduct = By.CssSelector(".mr-3.my-auto");

        public BasketWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckCountProduct() { 
            Assert.That(driver.FindElement(_countProduct).Text, Is.EqualTo("1 шт."));
        }

    }
}
