using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTests.PageObject;
// C:\Users\n2309\.nuget\packages\nunit.consolerunner\3.16.3\tools

namespace SeleniumTests
{
    public class Testsage 
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        public ChromeOptions options;

        [SetUp]
        public void Setup()
        {
            var options = new OpenQA.Selenium.Chrome.ChromeOptions();
            options.BinaryLocation = @"C:\Users\user\AppData\Local\Google\Chrome\Application\chrome.exe";
            driver = new ChromeDriver("C:\\webdriver\\chromedriver-win64", options);
            
            driver.Navigate().GoToUrl("https://megatop.by/");
            verificationErrors = new StringBuilder();
           
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                driver.Quit();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void Test1()
        {

            var modalSelectWindow = new ModalWindowPageObject(driver);
            modalSelectWindow.SelectCity();
            Thread.Sleep(1000);
            modalSelectWindow.SelectCookie();
            Thread.Sleep(1000);
            var mainWindow = new MainWindowPageObject(driver);
            Thread.Sleep(3000);
            CategoryWindowPageObject categoryWindow = mainWindow.GoToCategory("Галантерея");
            Thread.Sleep(3000);
            categoryWindow.GoToSubCategory("Кошельки");
            Thread.Sleep(3000);
            categoryWindow.AddToBasket();
            Thread.Sleep(3000);
            BasketWindowPageObject basketWindow = categoryWindow.GoBasket();
            Thread.Sleep(3000);
            basketWindow.CheckCountProduct();
        }   

        [Test]
        public void Test2()
        {
            var modalSelectWindow = new ModalWindowPageObject(driver);
            modalSelectWindow.SelectCity();
            Thread.Sleep(3000);
            modalSelectWindow.SelectCookie();
            Thread.Sleep(3000);
            var mainWindow = new MainWindowPageObject(driver);
            Thread.Sleep(3000);
            CategoryWindowPageObject categoryWindow = mainWindow.GoToCategory("Галантерея");
            Thread.Sleep(4000);
            categoryWindow.GoToSubCategory("Сумки");
            Thread.Sleep(3000);
            categoryWindow.FilterByPrice();


        }
    }
}