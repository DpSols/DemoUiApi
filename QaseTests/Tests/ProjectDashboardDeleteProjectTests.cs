using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;
using QaseServices.Project.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Project Dashboard Delete Project Tests")]
public class ProjectDashboardDeleteProjectTests : Test
{
    private ProjectsDashboardSteps ProjectsDashboardSteps {get; set; }
    
    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(5));
    
    [SetUp]
    public void SetUp()
    {
        ProjectsDashboardSteps = new ProjectsDashboardSteps(BrowserService, "Dashboard Page");
        
        Authenticate();

        ProjectsDashboardSteps.CreateProject(_testProject)
            .OpenProjectsDashboardPage();
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Delete Last Project Test")]
    [AllureSubSuite("Project")]
    public void DeleteLastProjectTest()
    {
        ProjectsDashboardSteps.DeleteProject(_testProject.Title)
            .OpenProjectsDashboardPage();
        
        var projects = ProjectsDashboardSteps.GetProjects();
        var isDeleted = projects.All(project => project.Title != _testProject.Title);
        
        Assert.That(isDeleted, Is.True, "The name of project shouldn't be on the dashboard.");
    }
    
    [TearDown]
    public void TearDown()
    {
        BrowserService.Browser.Quit();
    }
}