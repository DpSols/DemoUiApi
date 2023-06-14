using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectDefectCreatePage : ProjectBasePage
{
    private readonly By _defectTitleInputLocator = By.CssSelector("#title");
    private readonly By _defectActualResultInputLocator = By.CssSelector("#actual_result");
    private readonly By _defectSubmitButtonLocator = By.CssSelector(".save-button");
    private readonly By _severityFieldButtonLocator = By.CssSelector(".css-1wy0on6");
    private readonly By _severityInputLocator = By.XPath("//div[@class='flex-grow-1 css-2b097c-container']//input[@id='react-select-2-input']");

    private IWebElement DefectTitleInput =>
        Browser.WebDriver.FindElement(_defectTitleInputLocator);
    private IWebElement DefectActualResultInput =>
        Browser.WebDriver.FindElement(_defectActualResultInputLocator);
    private IWebElement DefectSubmitButton =>
        Browser.WebDriver.FindElement(_defectSubmitButtonLocator);
    private IWebElement SeverityFieldButton =>
        Browser.WebDriver.FindElement(_severityFieldButtonLocator);
    private IWebElement SeverityInput =>
        Browser.WebDriver.FindElement(_severityInputLocator);
    
    public ProjectDefectCreatePage(IBrowserService browserService, string pageName, string projectCode)
        : base(browserService, pageName, projectCode)
    {
    }
    
    protected override string UrlPath => $"/defect/{ProjectCode}/create";

    public void ClickDefectSubmitButton()
    {
        DefectSubmitButton.Click();
        AlertHandleHelper.HandleAlert(Browser);
    }
    
    public void ClickSeverityFieldButton()
    {
        SeverityFieldButton.Click();
    }
    
    public void InputSeverity(string severity)
    {
        SeverityInput.SendKeys(severity);
    }
    
    public void InputDefectTitle(string title)
    {
        DefectTitleInput.SendKeys(title);
    }
    
    public void InputDefectActualResult(string actualResult)
    {
        DefectActualResultInput.SendKeys(actualResult);
    }
}