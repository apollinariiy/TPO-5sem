using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumTests.PageObject
{
    public class CategoryWindowPageObject
    {
        private IWebDriver driver;

        private string url = "https://megatop.by/catalog/zhenshchiny/galantereya/koshelki";

        private readonly By _addbasketButton = By.XPath("//*[@id=\"app\"]/div[1]/div[7]/div[2]/div/div[4]/div[2]/div/div[2]/div/div[1]/div/div/div[1]/button[2]");
        private readonly By _gobasketButton = By.XPath("//*[@id=\"app\"]/div[2]/aside/div[1]/div/div/div[2]/div[2]/div[4]/button[1]");
        private readonly By _filterpriceButton = By.XPath("//*[@id=\"filter-price\"]/button");
        private readonly By _selectpriceInput = By.CssSelector("input[type='radio'][value='5']");
        private readonly By _selectpriceButton = By.XPath("//*[@id=\"filter-price\"]/div[2]/div/div[2]/button");
        private readonly By _price = By.CssSelector("div.product__price span.font-weight-medium");
        private readonly By _allprice = By.CssSelector("div.product__price");

        public CategoryWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }
        public CategoryWindowPageObject GoToSubCategory(string linkText) {
            IWebElement linkElement = driver.FindElement(By.XPath($"//span[contains(text(), '{linkText}')]"));
            linkElement.Click();
            return this;
        }

        public void AddToBasket() {
            driver.FindElement(_addbasketButton).Click();
        }
        public void AddToBasketTwo()
        {
            driver.FindElement(_addbasketButton).Click();
            Thread.Sleep(1000);
            Actions actions = new Actions(driver);
            actions.MoveByOffset(200, 200).Click().Perform();
            Thread.Sleep(1000);

            driver.FindElement(_addbasketButton).Click();

        }

        public BasketWindowPageObject GoBasket() {
            driver.FindElement(_gobasketButton).Click();
        return new BasketWindowPageObject(driver);
        }

        public void SelectFilter() {
            driver.FindElement(_filterpriceButton).Click();
            Thread.Sleep(1000);
            driver.FindElement(_selectpriceInput).Click();
            Thread.Sleep(1000);
            driver.FindElement(_selectpriceButton).Click();
            Thread.Sleep(1000);
        }
        public bool CheckFilterByPrice() {
            IList<IWebElement> elements = driver.FindElements(_price);
            foreach (IWebElement element in elements)
            {
                int value = int.Parse(element.Text);
                if (value > 50)
                {
                   return false;
                }
                
            }
            
           return true;
        }

        public bool CheckByPrice() {
            IWebElement elements = driver.FindElement(_allprice);
            if (elements.Text.Contains("₽"))
            {
                return true;
            }
            else { 
                return false;
            }
        }
    }
}
