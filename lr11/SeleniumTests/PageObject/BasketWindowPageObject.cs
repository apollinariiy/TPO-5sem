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
        private readonly By _saleText = By.XPath($"//*[contains(text(), 'Скидка МЕГАТОП')]");
        private readonly By _orderButton = By.XPath("//span[contains(text(), 'Оформить заказ')]");

        



        public BasketWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool CheckCountProduct()
        {
            string actualCount = driver.FindElement(_countProduct).Text;
            string expectedCount = "1 шт.";

            if (actualCount.Equals(expectedCount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSale()
        {
            IWebElement elem = driver.FindElement(_saleText);
            if (elem != null)
            {
                return true;
            }
            else return false;
        }
        public void DoOrder()
        {
            driver.FindElement(_orderButton).Click();
        }

    }
}
