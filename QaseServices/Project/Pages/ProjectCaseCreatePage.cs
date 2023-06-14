using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectCaseCreatePage : ProjectBasePage
{
    private readonly By _caseTitleInputLocator = By.CssSelector("#title");
    private readonly By _saveButtonLocator = By.CssSelector("#save-case");
    private readonly By _confirmMessageLabelLocator = By.XPath("//span[text()='Test case was created successfully!']");

    public ProjectCaseCreatePage(IBrowserService browserService, string pageName, string projectCode)
        : base(browserService, pageName, projectCode)
    {
    }

    protected override string UrlPath => $"/case/{ProjectCode}/create";

    private IWebElement ConfirmMessageLabel =>
        Browser.WebDriver.FindElement(_confirmMessageLabelLocator);
    private IWebElement CaseTitleInput =>
        Browser.WebDriver.FindElement(_caseTitleInputLocator);
    private IWebElement SaveAndCreateButton =>
        Browser.WebDriver.FindElement(_saveButtonLocator);

    public void InputCaseTitle(string title)
    {
        CaseTitleInput.SendKeys(title);
    }

    public void ClickSaveAndCreateCase()
    {
        SaveAndCreateButton.Click();
        AlertHandleHelper.HandleAlert(Browser);
    }
}