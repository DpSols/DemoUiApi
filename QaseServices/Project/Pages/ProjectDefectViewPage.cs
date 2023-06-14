using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices.Project.Pages;

public class ProjectDefectViewPage : ProjectBasePage
{
    private readonly By _defectTitleLocator = By.XPath("//h1");
    private readonly By _defectSeverityLocator = By.XPath("//i/parent::div");
    private readonly By _defectDescriptionLocator = By.XPath("//div[@class='defect-result mt-3']//p[@data-nodeid='3']");
    
    private IWebElement DefectTitleLabel =>
        Browser.WebDriver.FindElement(_defectTitleLocator);
    private IWebElement DefectSeverityLabel =>
        Browser.WebDriver.FindElement(_defectSeverityLocator);
    private IWebElement DefectDescriptionLabel =>
        Browser.WebDriver.FindElement(_defectDescriptionLocator);
    
    public ProjectDefectViewPage(IBrowserService browserService, string pageName, string projectCode) : base(browserService, pageName, projectCode)
    {
    }

    public string GetDefectTitle()
    {
        return DefectTitleLabel.Text;
    }
    
    public string GetDefectDescription()
    {
        return DefectDescriptionLabel.Text;
    }
    
    public string GetDefectSeverity()
    {
        return DefectSeverityLabel.Text;
    }
}