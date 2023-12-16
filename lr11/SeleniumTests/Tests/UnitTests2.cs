using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class UnitTests2
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
        }

        [Test]
        public void Test10()
        {
            steps.CloseModalWindows();
            steps.OpenSubcategoryPage();
            steps.AddProductToBusketAndGoToBasket();
            steps.DoOrder();
            var title = steps.GetTitle();
            Assert.That(title, Is.EqualTo("Оформление заказа MEGATOP"));
        }
    }
}
