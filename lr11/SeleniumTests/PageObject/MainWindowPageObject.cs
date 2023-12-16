using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.PageObject
{

    public class MainWindowPageObject
    {
        private IWebDriver driver;
        private string url = "https://megatop.by/zhenshchiny";
        private string urlProduct = "https://megatop.by/products/1605000264-botinki-o_live_naturalle";
        private string urlError = "https://megatop.by/kdxlsxs";
        private string urlBag = "https://megatop.by/catalog/zhenshchiny/galantereya/sumki";
        private string urlBagRU = "https://megatop.ru/catalog/zhenshchiny/galantereya/sumki";
        private string urlWallet = "https://megatop.by/catalog/zhenshchiny/galantereya/koshelki";
        private readonly By searchButton = By.CssSelector(".v-responsive__content[style='width: 24px;']");
        private readonly By inputSearch = By.CssSelector("input[autofocus='autofocus']");
        private readonly By _basketButton = By.XPath("//*[@id=\"header-top\"]/div[5]/div/div/div[3]/a/span");
        private readonly By _moneyButton = By.CssSelector("[role='button']");
        private readonly By _selectmoneyButton = By.CssSelector("div.content a");
        private readonly By _changeCity = By.CssSelector("div.block__text[data-v-04119da1]");
        private readonly By _selectedCity = By.CssSelector(".v-select__selection--comma");
        private readonly By _shopButton = By.LinkText("Магазины");

        
        public MainWindowPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void GoToPage() {
            driver.Navigate().GoToUrl(url);
        }
        public void GoToPageBag()
        {
            driver.Navigate().GoToUrl(urlBag);
        }
        public void GoToPageBagRU()
        {
            driver.Navigate().GoToUrl(urlBagRU);
        }
        public void OpenProduct()
        {
            driver.Navigate().GoToUrl(urlProduct);
        }
        public void GoToPageWallet()
        {
            driver.Navigate().GoToUrl(urlWallet);
        }
        public void OpenErrorPage()
        {
            driver.Navigate().GoToUrl(urlError);
        }
        public void GoToBasket() { 
        driver.FindElement(_basketButton).Click();
        }

        public CategoryWindowPageObject GoToCategory(string linkText) {
            IWebElement linkElement = driver.FindElement(By.XPath($"//a[contains(text(), '{linkText}')]"));
            linkElement.Click();
            return new CategoryWindowPageObject(driver);
        }

        public void ClickSearch() {
            IWebElement webElement = driver.FindElement(searchButton);
            webElement.Click();
        }
        public void DoSearch()
        {
            IWebElement linkElement = driver.FindElement(inputSearch);
            linkElement.SendKeys("Обувь");
            linkElement.SendKeys(Keys.Enter);        }

        public void ChangeMoney() {
            driver.FindElement(_moneyButton).Click();
            Thread.Sleep(1000);
            driver.FindElement(_selectmoneyButton).Click();
        }

        public void ChangeCity(string linkText)
        {
            driver.FindElement(_changeCity).Click();
            Thread.Sleep(3000);
            IWebElement linkElement = driver.FindElement(By.XPath($"//div[contains(text(), '{linkText}')]"));
            linkElement.Click();
        }
        public bool CheckSelectedCity() {
            driver.FindElement(_shopButton).Click();
            Thread.Sleep(3000);
            string str = driver.FindElement(_selectedCity).Text;
            if (str.Contains("Бобруйск")) return true;
            else return false;
        }


        ////*[@id="catalog"]/div[1]/div[3]/a
        /////*[@id="catalog"]/div[1]/div[2]/a
    }
}
