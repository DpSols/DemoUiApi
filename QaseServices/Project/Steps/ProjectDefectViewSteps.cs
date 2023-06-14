using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectDefectViewSteps
{
    private readonly ProjectDefectViewPage _projectDefectViewPage;

    public ProjectDefectViewSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectDefectViewPage = new ProjectDefectViewPage(browserService, pageName, projectCode);
    }
    
    [AllureStep("Getting Project Defect.")]
    public TestDefect GetProjectDefect()
    {
        Logger.Instance.Info("Getting Project Defect.");
        var title = _projectDefectViewPage.GetDefectTitle();
        var description = _projectDefectViewPage.GetDefectDescription();
        var severity = Enum.Parse<Severity>(_projectDefectViewPage.GetDefectSeverity());
        
        return new TestDefect(title, description, severity);
    }
}