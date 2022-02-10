using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumGrid.Helpers
{
    public static class LocalDriverFactory
    {
        public static IWebDriver CreateInstance(BrowserType browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    var options = new EdgeOptions();
                    driver = new EdgeDriver(options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }

        public static IWebDriver CreateInstance(BrowserType browserType, string hubUrl)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--no-sandbox");
                    driver = GetWebDriver(hubUrl, chromeOptions.ToCapabilities());
                    break;
                case BrowserType.Edge:
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--no-sandbox");
                    driver = GetWebDriver(hubUrl, edgeOptions.ToCapabilities());
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = GetWebDriver(hubUrl, firefoxOptions.ToCapabilities());
                    break;
            }

            return driver;
        }

        private static IWebDriver GetWebDriver(string hubUrl, ICapabilities capabilities)
        {
            TimeSpan timeSpan = new TimeSpan(0, 3, 0);
            return new RemoteWebDriver(
                        new Uri(hubUrl),
                        capabilities,
                        timeSpan
                    );
        }
    }
}
