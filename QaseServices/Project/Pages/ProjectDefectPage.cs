using System.Collections.ObjectModel;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectDefectPage : ProjectBasePage
{
    private readonly By _defectTitlesLabelLocator = By.CssSelector(".defect-title");

    private ReadOnlyCollection<IWebElement> DefectTitlesLabels =>
        Browser.WebDriver.FindElements(_defectTitlesLabelLocator);

    public ProjectDefectPage(IBrowserService browserService, string pageName, string projectCode) : base(browserService, pageName, projectCode)
    {
    }

    public IEnumerable<string> GetDefectTitles()
    {
        return DefectTitlesLabels.Select(label => label.Text);
    }
}