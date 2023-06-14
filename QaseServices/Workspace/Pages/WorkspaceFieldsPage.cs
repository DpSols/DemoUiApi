using System.Collections.ObjectModel;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Workspace.Pages;

public class WorkspaceFieldsPage : WorkspaceBasePage
{
    private readonly By _fieldProjectsLabelsLocator = By.CssSelector(".projects-avatars-list span");
    private readonly By _fieldEditButtonsLocator = By.CssSelector("tr td[class=''] div");
    private readonly By _enableForAllProjectCheckboxLocator = By.CssSelector("input[type='checkbox']");
    private readonly By _fieldEditConfirmButtonLocator = By.XPath("//span[text()='Save']/parent::*");

    private ReadOnlyCollection<IWebElement> FieldProjectsLabel =>
        Browser.WebDriver.FindElements(_fieldProjectsLabelsLocator);
    private ReadOnlyCollection<IWebElement> FieldEditButtons =>
        Browser.WebDriver.FindElements(_fieldEditButtonsLocator);
    private IWebElement FieldEditConfirmButton =>
        Browser.WebDriver.FindElement(_fieldEditConfirmButtonLocator);
    private IWebElement FieldEnableForAllProjectCheckbox =>
        Browser.WebDriver.FindElement(_enableForAllProjectCheckboxLocator);

    public WorkspaceFieldsPage(IBrowserService browser, string pageName) : base(browser, pageName)
    {
    }

    protected override string UrlPath => "/workspace/fields";

    public string GetFieldProjectsText(int index)
    {
        var projectLabels = FieldProjectsLabel;
        
        return projectLabels[index].Text;
    }
    
    public void ClickFieldEditButton(int index)
    {
        FieldEditButtons[index].Click();
    }
    
    public void ClickFieldEditConfirmButton()
    {
        FieldEditConfirmButton.Click();
    }
    
    public void ClickFieldEnableForAllProjectCheckbox()
    {
        FieldEnableForAllProjectCheckbox.Click();
    }
}