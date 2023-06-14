using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectDefectDashboardPage : ProjectBasePage
{
    private readonly By _firstDefectTitleLocator = By.CssSelector("#defect-1-title");
    
    private IWebElement FirstDefectTitle =>
        Browser.WebDriver.FindElement(_firstDefectTitleLocator);

    public ProjectDefectDashboardPage(IBrowserService browserService, string pageName, string projectCode) : base(browserService, pageName, projectCode)
    {
    }

    protected override string UrlPath => $"defect/{ProjectCode}";

    public string GetDefectTitle()
    {
        return FirstDefectTitle.Text;
    }

    public void ClickFirstDefect()
    {
        FirstDefectTitle.Click();
        AlertHandleHelper.HandleAlert(Browser);
    }
}