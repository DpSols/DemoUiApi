using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectDefectDashboardSteps
{
    private readonly ProjectDefectDashboardPage _projectDefectDashboardPage;
    
    public ProjectDefectDashboardSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectDefectDashboardPage = new ProjectDefectDashboardPage(browserService, pageName, projectCode);
    }
    
    [AllureStep("Opening view of defect.")]
    public ProjectDefectDashboardSteps OpenDefectViewPage()
    {
        Logger.Instance.Info("Opening view of defect.");
        _projectDefectDashboardPage.ClickFirstDefect();

        return this;
    }
}