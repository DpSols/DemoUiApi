using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectRepositoryPage : ProjectBasePage
{
    private readonly By _createCaseLinkLocator = By.CssSelector("#create-case-button");
    private readonly By _searchInputLocator = By.CssSelector(".form-control.search-input");
    private readonly By _projectCodeLocator = By.XPath("//h1");
    private readonly By _projectNameLocator = By.CssSelector(".LALnEw");
    private readonly By _projectSettingsLinkLocator = By.XPath("//a[@title='Settings']");
    private readonly By _testCasesLocator = By.XPath("//div[@data-suite-body-id='0'][@draggable='true']/div[5]");

    public ProjectRepositoryPage(IBrowserService browserService, string pageName, string projectCode)
        : base(browserService, pageName, projectCode)
    {
    }

    protected override string UrlPath => $"/project/{ProjectCode}";

    private ReadOnlyCollection<IWebElement> TestCasesLabel =>
        Browser.WebDriver.FindElements(_testCasesLocator);
    private IWebElement ProjectNameLabel =>
        Browser.WebDriver.FindElement(_projectNameLocator);
    private IWebElement ProjectSettingsLink =>
        Browser.WebDriver.FindElement(_projectSettingsLinkLocator);
    private IWebElement ProjectCodeLabel =>
        Browser.WebDriver.FindElement(_projectCodeLocator);
    private IWebElement CreateCaseLink =>
        Browser.WebDriver.FindElement(_createCaseLinkLocator);
    private IWebElement SearchInput =>
        Browser.WebDriver.FindElement(_searchInputLocator);

    public void CreateCaseClick()
    {
        CreateCaseLink.Click();
    }

    public IEnumerable<string> GetTestCaseTitles()
    {
        return TestCasesLabel.Select(testCase => testCase.Text);
    }

    public void InputSearch(string text)
    {
        SearchInput.SendKeys(text);
    }

    public string GetProjectCode()
    {
        var projectCodeText = ProjectCodeLabel.Text;
        var index = projectCodeText.IndexOf(" repository", StringComparison.InvariantCulture);
        var strBuilder = new StringBuilder(projectCodeText);
        var codeName = strBuilder.Remove(index, strBuilder.Length-index).ToString();

        return codeName;
    }
    
    public string GetProjectName()
    {
        return ProjectNameLabel.Text;
    }
    
    public void OpenProjectSettings()
    {
        ProjectSettingsLink.Click();
    }
}