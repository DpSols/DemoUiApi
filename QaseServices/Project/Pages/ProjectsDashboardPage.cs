using System.Collections.ObjectModel;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;
using QaseCore.PageForms;

namespace QaseServices.Project.Pages;

public class ProjectsDashboardPage : BaseForm
{
    private readonly By _defectTitleLocator = By.CssSelector(".defect-title");
    private readonly By _createProjectButtonLocator = By.CssSelector("#createButton");
    private readonly By _deleteProjectButtonLocator = By.XPath("//button[text()='Delete']");
    private readonly By _deleteProjectConfirmButtonLocator = By.XPath("//span[text()='Delete project']/parent::*");
    private readonly By _projectDropdownButtonLocator = By.CssSelector(".btn.btn-dropdown");
    private readonly By _projectNameInputLocator = By.CssSelector("#project-name");
    private readonly By _projectCodeInputLocator = By.CssSelector("#project-code");
    private readonly By _createProjectSubmitButtonLocator = By.XPath("//button[@type='submit']");

    private IWebElement CreateProjectButton =>
        Browser.WebDriver.FindElement(_createProjectButtonLocator);
    private ReadOnlyCollection<IWebElement> ProjectDropdownButton =>
        Browser.WebDriver.FindElements(_projectDropdownButtonLocator);
    private ReadOnlyCollection<IWebElement> ProjectDeleteButton =>
        Browser.WebDriver.FindElements(_deleteProjectButtonLocator);
    private IWebElement ProjectDeleteConfirmButton =>
        Browser.WebDriver.FindElement(_deleteProjectConfirmButtonLocator);
    private IWebElement ProjectNameInput =>
        Browser.WebDriver.FindElement(_projectNameInputLocator);
    private IWebElement ProjectCodeInput =>
        Browser.WebDriver.FindElement(_projectCodeInputLocator);
    private IWebElement CreateProjectSubmitButton =>
        Browser.WebDriver.FindElement(_createProjectSubmitButtonLocator);
    private ReadOnlyCollection<IWebElement> ProjectLabels =>
        Browser.WebDriver.FindElements(_defectTitleLocator);
    
    public ProjectsDashboardPage(IBrowserService browserService, string pageName) : base(browserService, pageName)
    {
    }
    
    protected override string BaseUrl => "https://app.qase.io";
    protected override string UrlPath => "/projects";
    
    public void ClickOnProject(int index)
    {
        ProjectLabels[index].Click();
    }

    public IEnumerable<string> GetProjectsTitles()
    {
        return ProjectLabels.Select(labels => labels.Text);
    }
    
    public void ClickCreateProject()
    {
        CreateProjectButton.Click();
    }
    
    public void ClickProjectDeleteConfirmButton()
    {
        ProjectDeleteConfirmButton.Click();
    }
    
    public void ClickProjectDropdownButton(int index)
    {
        ProjectDropdownButton[index].Click();
    }
    
    public void ClickProjectDeleteButton(int index)
    {
        ProjectDeleteButton[index].Click();
    }

    public void InputProjectName(string name)
    {
        ProjectNameInput.SendKeys(name);
    }

    public void ClearProjectCode()
    {
        ProjectCodeInput.Clear();
    }

    public void InputProjectCode(string code)
    {
        ProjectCodeInput.Clear();
        ProjectCodeInput.SendKeys(code);
    }

    public void ProjectCreationSubmitClick()
    {
        CreateProjectSubmitButton.Click();
    }
}