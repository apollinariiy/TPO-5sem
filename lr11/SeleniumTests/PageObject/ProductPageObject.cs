using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PageObject
{
    public class ProductPageObject
    {
        private IWebDriver driver;

        private readonly By _shareButton = (By.CssSelector("div.share__text"));


        public ProductPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ShareProduct() { 
        driver.FindElement(_shareButton).Click();
        }
        public bool CheckShareProduct() {
            IWebElement element = driver.FindElement(By.CssSelector("div.share__copy-link"));
            if (element != null)
            {
                return true;
            }
            else return false;
        }
    }
}
