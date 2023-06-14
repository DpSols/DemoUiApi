using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Models;
using QaseServices.Project.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Project Dashboard Create Project Tests")]
public class ProjectDashboardCreateProjectTests : Test
{
    private ProjectsDashboardSteps ProjectsDashboardSteps {get; set; }
    private ProjectRepositorySteps ProjectRepositorySteps {get; set; }
    private ProjectSettingsSteps ProjectSettingsSteps {get; set; }

    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(8).ToUpper());

    [SetUp]
    public void SetUp()
    {
        ProjectsDashboardSteps = new ProjectsDashboardSteps(BrowserService, "Dashboard Page");
        ProjectRepositorySteps = new ProjectRepositorySteps(BrowserService, "Project Repository Page", _testProject.Code);
        ProjectSettingsSteps = new ProjectSettingsSteps(BrowserService, "Project Settings Page", _testProject.Code);
        
        Authenticate();
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Create Project Test")]
    [AllureSubSuite("Project")]
    public void CreateProjectTest()
    {
        ProjectsDashboardSteps.CreateProject(_testProject)
            .OpenProjectsDashboardPage()
            .OpenProject(_testProject.Title);
        
        var project = ProjectRepositorySteps.GetTestProject();
        
        Assert.That(project, Is.EqualTo(_testProject), "The created project should have specified title and code.");
    }
    
    [TearDown]
    public void TearDown()
    {
        ProjectsDashboardSteps.OpenProjectsDashboardPage()
            .DeleteProject(_testProject.Title);
        
        BrowserService.Browser.Quit();
    }
}