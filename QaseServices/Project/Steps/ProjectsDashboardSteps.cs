using NUnit.Allure.Attributes;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Pages;
using QaseServices.Project.Models;

namespace QaseServices.Project.Steps;

public class ProjectsDashboardSteps
{
    private readonly ProjectsDashboardPage _projectsDashboardPage;
    
    public ProjectsDashboardSteps(IBrowserService browserService, string pageName)
    {
        _projectsDashboardPage = new ProjectsDashboardPage(browserService, pageName);
    }

    [AllureStep("Creating a new project.")]
    public ProjectsDashboardSteps CreateProject(TestProject project)
    {
        Logger.Instance.Info("Creating a new project.");
        _projectsDashboardPage.ClickCreateProject();
        _projectsDashboardPage.InputProjectName(project.Title);
        _projectsDashboardPage.ClearProjectCode();
        _projectsDashboardPage.InputProjectCode(project.Code);
        _projectsDashboardPage.ProjectCreationSubmitClick();

        return this;
    }

    [AllureStep("Deleting the project.")]
    public ProjectsDashboardSteps DeleteProject(string name)
    {
        Logger.Instance.Info("Deleting the project.");
        var titles = _projectsDashboardPage.GetProjectsTitles().ToList();
        var index = titles.FindIndex(title => title == name);
        
        if (index == -1)
        {
            throw new ArgumentException("There is no project with this name!");
        }
        
        _projectsDashboardPage.ClickProjectDropdownButton(index);
        _projectsDashboardPage.ClickProjectDeleteButton(index);
        _projectsDashboardPage.ClickProjectDeleteConfirmButton();

        return this;
    }
    
    [AllureStep("Opening Projects Dashboard Page.")]
    public ProjectsDashboardSteps OpenProjectsDashboardPage()
    {
        Logger.Instance.Info("Opening Projects Dashboard Page.");
        _projectsDashboardPage.OpenPage();
        
        return this;
    }
    
    [AllureStep("Getting the Projects.")]
    public IEnumerable<TestProject> GetProjects()
    {
        Logger.Instance.Info("Getting the Projects.");
        var projects = _projectsDashboardPage.GetProjectsTitles()
            .Select(title => new TestProject(title, ""));
        
        return projects;
    }
    
    [AllureStep("Opening Project's Page.")]
    public ProjectsDashboardSteps OpenProject(string name)
    {
        Logger.Instance.Info("Opening Project's Page.");
        var titles = _projectsDashboardPage.GetProjectsTitles().ToList();
        var index = titles.FindIndex(title => title == name);
        
        if (index == -1)
        {
            throw new ArgumentException("There is no project with this name!");
        }
        
        _projectsDashboardPage.ClickOnProject(index);
        
        return this;
    }
}