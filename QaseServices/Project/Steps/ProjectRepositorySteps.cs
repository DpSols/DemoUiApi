using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectRepositorySteps
{
    private readonly ProjectRepositoryPage _projectRepositoryPage;

    public ProjectRepositorySteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectRepositoryPage = new ProjectRepositoryPage(browserService, pageName, projectCode);
    }

    [AllureStep("Opening Project Repository Page.")]
    public ProjectRepositorySteps OpenProjectRepositoryPage()
    {
        Logger.Instance.Info("Opening Project Repository Page.");
        _projectRepositoryPage.OpenPage();

        return this;
    }
    
    [AllureStep("Getting the Project.")]
    public TestProject GetTestProject()
    {
        Logger.Instance.Info("Getting the Project.");
        var code = _projectRepositoryPage.GetProjectCode();
        var name = _projectRepositoryPage.GetProjectName();
        
        return new TestProject(name, code);
    }
    
    [AllureStep("Opening Project Settings.")]
    public ProjectRepositorySteps OpenProjectSettings()
    {
        Logger.Instance.Info("Opening Project Settings.");
        _projectRepositoryPage.OpenProjectSettings();
        
        return this;
    }
    
    [AllureStep("Getting test cases.")]
    public IEnumerable<ProjectTestCase> GetTestCases()
    {
        Logger.Instance.Info("Getting test cases.");
        var testCases = _projectRepositoryPage.GetTestCaseTitles().Select(title => new ProjectTestCase(title));
        
        return testCases;
    }
}