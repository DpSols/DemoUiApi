using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;

namespace QaseCore.PageForms;

public abstract class BaseForm
{
    public IBrowser Browser { get; }
    private WebDriverWait WebDriverWait => Browser.WebDriverWait;
    protected abstract string BaseUrl { get; }
    protected abstract string UrlPath { get; }
    protected string PageName { get; }

    protected BaseForm(IBrowserService browser, string pageName)
    {
        Browser = browser.Browser;
        PageName = pageName;
    }

    public string Title => Browser.WebDriver.Title;

    public void OpenPage()
    {
        var uri = new Uri(BaseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Debug($"Opening page {PageName}");
        Browser.GoToUrl(uri);
        WaitForPageLoad();
    }
    
    private void WaitForPageLoad()
    {
        WebDriverWait.Until(_ => Browser.WebDriver
            .ExecuteScript("return document.readyState")
            .Equals("complete"));
    }
}