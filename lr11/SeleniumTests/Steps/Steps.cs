using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver  = Driver.DriverInstance.GetInstance();
        }
        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void CloseModalWindows()
        {
            MainWindowPageObject mainPage = new MainWindowPageObject(driver);
            mainPage.GoToPage();
            var modalSelectWindow = new ModalWindowPageObject(driver);
            modalSelectWindow.SelectCity();
            Thread.Sleep(1000);
            modalSelectWindow.SelectCookie();
            Thread.Sleep(1000);

        }

        public void AddProductToBusketAndGoToBasket() {
            CategoryWindowPageObject categoryWindowPageObject = new CategoryWindowPageObject(driver);
            categoryWindowPageObject.AddToBasket();
            Thread.Sleep(4000);
            categoryWindowPageObject.GoBasket();
        }
        public bool AddTwoProductToBusketAndGoToBasket()
        {
            CategoryWindowPageObject categoryWindowPageObject = new CategoryWindowPageObject(driver);
            categoryWindowPageObject.AddToBasketTwo();
            Thread.Sleep(3000);
            categoryWindowPageObject.GoBasket();
            Thread.Sleep(3000);
            var basket = new BasketWindowPageObject(driver);
            if (basket.CheckSale()) return true;
            else return false;

        }

        public void OpenSubcategoryPage() {
            var mainWindow = new MainWindowPageObject(driver);
            Thread.Sleep(4000);
            CategoryWindowPageObject categoryWindow = mainWindow.GoToCategory("Галантерея");
            Thread.Sleep(4000);
            categoryWindow.GoToSubCategory("Кошельки");
            Thread.Sleep(4000);
        }
        public string GetTitle() {
            return driver.Title;
        }

        public bool CheckCountProductInBasket() {
            BasketWindowPageObject basket = new BasketWindowPageObject(driver);
            Thread.Sleep(3000);
            if (basket.CheckCountProduct()) { return true; }
            else { return false; }
        }

        public void GoToPageWallet() {
            CategoryWindowPageObject cat = new CategoryWindowPageObject(driver);
            cat.GoToPage();
            Thread.Sleep(3000);

        }
        public void GoToPageBag() { 
        MainWindowPageObject mainPage = new MainWindowPageObject(driver);
        mainPage.GoToPageBag();
            Thread.Sleep(3000);
        }
        public void GoToPageBagRU()
        {
            MainWindowPageObject mainPage = new MainWindowPageObject(driver);
            mainPage.GoToPageBagRU();
            Thread.Sleep(3000);
        }
        public bool FilterByPrice()
        {
             CategoryWindowPageObject categoryWindowPage = new CategoryWindowPageObject(driver);
            categoryWindowPage.SelectFilter();
            Thread.Sleep(1000);
            if (categoryWindowPage.CheckFilterByPrice()) { 
            return true;
            }
            else { return false; }
        }

        public void SearchProduct() { 
        var main = new MainWindowPageObject(driver);
        main.ClickSearch();
            Thread.Sleep(3000);
        main.DoSearch();
            Thread.Sleep(3000);
        }

        public void ChangeMoney() {
            var main = new MainWindowPageObject(driver);
            main.ChangeMoney();
        }

        public bool CheckMoney()
        {
            var sub = new CategoryWindowPageObject(driver);
            if (sub.CheckByPrice()) { return true; }
            else { return false; }
        }

        public bool CheckShare() { 
            var main = new MainWindowPageObject(driver);
            main.OpenProduct();
            Thread.Sleep(3000);
            ProductPageObject productPage = new ProductPageObject(driver);
            productPage.ShareProduct();
            Thread.Sleep(3000);
            if(productPage.CheckShareProduct()) return true;
            else { return false; }
        }

        public void OpenErrorPage() { 
        var main = new MainWindowPageObject(driver);
            main.OpenErrorPage();
        }

        public bool ChangeCity() {
            var main = new MainWindowPageObject(driver);
            main.ChangeCity("Бобруйск");
            Thread.Sleep(1000);
            if (main.CheckSelectedCity()) return true;
            else return false;
        }

        public void DoOrder() {
            Thread.Sleep(3000);
        BasketWindowPageObject basket = new BasketWindowPageObject(driver);
        basket.DoOrder();
        }
    }
}
