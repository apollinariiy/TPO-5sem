using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTests.PageObject;
using SeleniumTests.Steps;
// C:\Users\n2309\.nuget\packages\nunit.consolerunner\3.16.3\tools

namespace SeleniumTests.Tests
{
    public class Testsage
    {

        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Setup()
        {
            steps.InitBrowser();

        }
        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void Test1()
        {

            steps.CloseModalWindows();
            steps.OpenSubcategoryPage();
            steps.AddProductToBusketAndGoToBasket();
            Assert.IsTrue(steps.CheckCountProductInBasket());
        }

        [Test]
        public void Test2()
        {
            steps.CloseModalWindows();
            steps.GoToPageBag();
            Assert.IsTrue(steps.FilterByPrice());
        }

        [Test]
        public void Test3()
        {
            steps.CloseModalWindows();
            steps.OpenSubcategoryPage();
            var title = steps.GetTitle();
            Assert.That(title, Is.EqualTo("Купить кошелек женский в Минске, каталог с ценами в интернет-магазине"));
        }

        [Test]
        public void Test4()
        {
            steps.CloseModalWindows();
            steps.SearchProduct();
            var title = steps.GetTitle();
            Assert.That(title, Is.EqualTo("🔍Поиск на сайте megatop.by"));
        }
        [Test]
        public void Test5()
        {
            steps.CloseModalWindows();
            steps.ChangeMoney();
            steps.GoToPageBagRU();
            Thread.Sleep(5000);
            Assert.IsTrue(steps.CheckMoney());
        }
       /* [Test]
        public void Test6()
        {
            steps.CloseModalWindows();
            Assert.IsTrue(steps.CheckShare());
        }

        [Test]
        public void Test7()
        {
            steps.CloseModalWindows();
            steps.OpenErrorPage();
            var title = steps.GetTitle();
            Assert.That(title, Is.EqualTo("404 Not Found"));
        }
        [Test]
        public void Test8()
        {
            steps.CloseModalWindows();
            Assert.IsTrue(steps.ChangeCity());

        }

        [Test]
        public void Test9()
        {
            steps.CloseModalWindows();
            steps.OpenSubcategoryPage();
            Assert.IsTrue(steps.AddTwoProductToBusketAndGoToBasket());
        }*/
    }
}