using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectSettingsSteps
{
    private readonly ProjectSettingsPage _projectSettingsPage;

    public ProjectSettingsSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectSettingsPage = new ProjectSettingsPage(browserService, pageName, projectCode);
    }

    [AllureStep("Deleting the Project.")]
    public ProjectSettingsSteps DeleteProject()
    {
        Logger.Instance.Info("Deleting the Project.");
        _projectSettingsPage.ClickProjectDeleteButton();
        _projectSettingsPage.ClickProjectDeleteConfirmButton();

        return this;
    }
}