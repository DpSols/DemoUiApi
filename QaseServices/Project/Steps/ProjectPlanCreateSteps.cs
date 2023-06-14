using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectPlanCreateSteps
{
    private readonly ProjectPlanCreatePage _projectPlanCreatePage;

    public ProjectPlanCreateSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectPlanCreatePage = new ProjectPlanCreatePage(browserService, pageName, projectCode);
    }

    
    [AllureStep("Creating a new plan with suites.")]
    public ProjectPlanCreateSteps CreatePlan(ProjectPlan plan)
    {
        Logger.Instance.Info("Creating a new plan with suites.");
        _projectPlanCreatePage.InputPlanTitle(plan.Title);
        _projectPlanCreatePage.ClickPlanEditAddCasesButton();
        _projectPlanCreatePage.ClickPlanSuiteCheckbox(0);
        _projectPlanCreatePage.ClickPlanTestCasesSubmitButton();
        _projectPlanCreatePage.ClickPlanSubmitButton();

        return this;
    }
}