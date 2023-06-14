using System.Collections.ObjectModel;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectPlanCreatePage : ProjectPlanPage
{
    private readonly By _planTitleInputLocator = By.CssSelector("#title");
    private readonly By _planEditAddCasesButtonLocator = By.CssSelector("#edit-plan-add-cases-button");
    private readonly By _planSuitesCheckboxesLocator = By.CssSelector("div.suite-left div.checkbox");
    private readonly By _planTestCasesSubmitButtonLocator = By.XPath("//span[text()='Done']/parent::button");
    private readonly By _planSubmitButtonLocator = By.CssSelector("#save-plan");

    private IWebElement PlanTitleInput =>
        Browser.WebDriver.FindElement(_planTitleInputLocator);
    private IWebElement PlanEditAddCasesButton =>
        Browser.WebDriver.FindElement(_planEditAddCasesButtonLocator);
    private IWebElement PlanSubmitButton =>
        Browser.WebDriver.FindElement(_planSubmitButtonLocator);
    private ReadOnlyCollection<IWebElement> PlanSuiteCheckboxes =>
        Browser.WebDriver.FindElements(_planSuitesCheckboxesLocator);
    private IWebElement PlanTestCasesSubmitButton =>
        Browser.WebDriver.FindElement(_planTestCasesSubmitButtonLocator);
   
    public ProjectPlanCreatePage(IBrowserService browserService, string pageName, string projectCode)
        : base(browserService, pageName, projectCode)
    {
    }
    
    protected override string UrlPath => $"/plan/{ProjectCode}/create";

    public void InputPlanTitle(string title)
    {
        PlanTitleInput.SendKeys(title);
    }
    
    public void ClickPlanEditAddCasesButton()
    {
        PlanEditAddCasesButton.Click();
    }
    
    public void ClickPlanSubmitButton()
    {
        PlanSubmitButton.Click();
    }
    
    public void ClickPlanSuiteCheckbox(int index)
    {
        PlanSuiteCheckboxes[index].Click();
    }
    
    public void ClickPlanTestCasesSubmitButton()
    {
        PlanTestCasesSubmitButton.Click();
    }
}