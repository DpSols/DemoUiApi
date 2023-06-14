using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectPlanSteps
{
    private readonly ProjectPlanPage _projectPlanPage;

    public ProjectPlanSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectPlanPage = new ProjectPlanPage(browserService, pageName, projectCode);
    }

    [AllureStep("Opening Project Plan Page.")]
    public ProjectPlanSteps OpenProjectPlanPage()
    {
        Logger.Instance.Info("Opening Project Plan Page.");
        _projectPlanPage.OpenPage();

        return this;
    }

    [AllureStep("Clicking on Create Link.")]
    public ProjectPlanSteps ClickCreateLink()
    {
        Logger.Instance.Info("Clicking on Create Link.");
        _projectPlanPage.ClickCreateLink();

        return this;
    }

    [AllureStep("Getting Project Plans.")]
    public IEnumerable<ProjectPlan> GetProjectPlans()
    {
        Logger.Instance.Info("Getting Project Plans.");
        var plans = _projectPlanPage.GetPlanTitles().Select(title => new ProjectPlan(title));
        
        return plans;
    }
}