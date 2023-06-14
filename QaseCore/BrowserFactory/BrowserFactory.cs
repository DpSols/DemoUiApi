using OpenQA.Selenium;
using QaseCore.BrowserFactory.ConcreteBrowsers;

namespace QaseCore.BrowserFactory
{
    public abstract class BrowserFactory
    {
        public string[] BrowserOptions { get; set; }
        public IBrowser GetBrowser => new Browser(WebDriver);
        protected abstract WebDriver WebDriver { get; }
    }
}