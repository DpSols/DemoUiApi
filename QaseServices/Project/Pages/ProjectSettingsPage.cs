using OpenQA.Selenium;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;

namespace QaseServices.Project.Pages;

public class ProjectSettingsPage : ProjectBasePage
{
    private readonly By _projectDeleteButtonLocator = By.XPath("//span[contains(text(),'Delete project')]/parent::button");
    private readonly By _projectDeleteConfirmButtonLocator = By.XPath("//div[contains(@class,'ReactModal__Content')]//span[contains(text(),'Delete project')]/parent::button");

    private IWebElement ProjectDeleteConfirmButton =>
        Browser.WebDriver.FindElement(_projectDeleteConfirmButtonLocator);
    
    protected override string UrlPath => $"/project/{ProjectCode}/settings/general";

    public ProjectSettingsPage(IBrowserService browserService, string pageName, string projectCode) : base(browserService, pageName, projectCode)
    {
    }

    public void ClickProjectDeleteButton()
    {
        Browser.WebDriver.FindElement(_projectDeleteButtonLocator)
            .Click();
    }
    
    public void ClickProjectDeleteConfirmButton()
    {
        ProjectDeleteConfirmButton.Click();;
    }
}