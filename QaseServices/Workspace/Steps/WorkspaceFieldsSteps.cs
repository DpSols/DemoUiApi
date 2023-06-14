using NUnit.Allure.Attributes;
using QaseCore.Utilities;
using QaseServices.Workspace.Pages;

namespace QaseServices.Workspace.Steps;

public class WorkspaceFieldsSteps
{
    private readonly WorkspaceFieldsPage _workspaceFieldsPage;

    public WorkspaceFieldsSteps(WorkspaceFieldsPage workspaceFieldsPage)
    {
        _workspaceFieldsPage = workspaceFieldsPage;
    }

    [AllureStep("Opening Workspace Fields Page.")]
    public WorkspaceFieldsSteps OpenPage()
    {
        Logger.Instance.Info("Opening Workspace Fields Page.");
        _workspaceFieldsPage.OpenPage();
        
        return this;
    }
    
    [AllureStep("Editing Enable For All Projects Attribute.")]
    public WorkspaceFieldsSteps EditEnableForAllProjects(int fieldIndex)
    {
        Logger.Instance.Info("Editing Enable For All Projects Attribute.");
        _workspaceFieldsPage.ClickFieldEditButton(fieldIndex);
        _workspaceFieldsPage.ClickFieldEnableForAllProjectCheckbox();
        _workspaceFieldsPage.ClickFieldEditConfirmButton();
        
        return this;
    }
}