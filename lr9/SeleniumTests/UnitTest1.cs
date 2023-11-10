using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
// C:\Users\n2309\.nuget\packages\nunit.consolerunner\3.16.3\tools

namespace SeleniumTests
{
    public class Tests
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        public ChromeOptions options;

        [SetUp]
        public void Setup()
        {
            options = new ChromeOptions();
            driver = new ChromeDriver("C:\\webdriver\\chromedriver-win64", options);
            baseURL = "https://megatop.by/catalog/zhenshchiny/galantereya";
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
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div/div/div/div[2]/button[1]")).Click();

            Assert.That(driver.Title, Is.EqualTo("∆енска€ галантере€ Ч купить в интернет-магазине ћегатоп"));
            driver.FindElement(By.ClassName("basket")).Click();

            Assert.That(driver.Title, Is.EqualTo("∆енска€ галантере€ Ч купить в интернет-магазине ћегатоп"));

            driver.Navigate().GoToUrl("https://megatop.by/cart");
            Assert.That(driver.Title, Is.EqualTo("ќформление заказа MEGATOP"));
            Assert.That(driver.FindElement(By.CssSelector(".mr-3.my-auto")).Text, Is.EqualTo("1 шт."));
        }
    }
}