using System.Collections.ObjectModel;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectPlanPage : ProjectBasePage
{
    private readonly By _createButtonLocator = By.CssSelector("#createButton");
    private readonly By _planTitleLinksLocator = By.CssSelector(".defect-title");
    
    private ReadOnlyCollection<IWebElement> PlanTitleLink =>
        Browser.WebDriver.FindElements(_planTitleLinksLocator);
    private IWebElement CreateLink =>
        Browser.WebDriver.FindElement(_createButtonLocator);

    public ProjectPlanPage(IBrowserService browserService, string pageName, string projectCode)
        : base(browserService, pageName, projectCode)
    {
    }
    
    protected override string UrlPath => $"/plan/{ProjectCode}";

    public void ClickCreateLink()
    {
        CreateLink.Click();
    }

    public IEnumerable<string> GetPlanTitles()
    {
        return PlanTitleLink.Select(link => link.Text);
    }
}