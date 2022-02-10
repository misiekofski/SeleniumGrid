using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using SeleniumGrid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumGrid
{
    [TestFixture(BrowserType.Edge)]
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    public class Tests
    {
        private IWebDriver driver;
        string hubUrl;

        public Tests(BrowserType browser)
        {
            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(browser, hubUrl);
        }

        [Test]
        [Parallelizable]
        public void OpenBingAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("Selenium Grid");

            driver.Quit();
        }
    }
}