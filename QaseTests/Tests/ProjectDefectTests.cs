using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Models;
using QaseServices.Project.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Project Defect Tests")]
public class ProjectDefectTests : Test
{
    private ProjectSettingsSteps ProjectSettingsSteps {get; set; }
    private ProjectRepositorySteps ProjectRepositorySteps {get; set; }
    private ProjectDefectCreateSteps ProjectDefectCreateSteps {get; set; }
    private ProjectsDashboardSteps ProjectsDashboardSteps {get; set; }
    private ProjectDefectViewSteps ProjectDefectViewSteps {get; set; }
    private ProjectDefectDashboardSteps ProjectDefectDashboardSteps {get; set; }
    
    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(7).ToUpper());
    private readonly TestDefect _testDefect = new TestDefect(RandomGenerator.RandomUniqueString(7),
        RandomGenerator.RandomUniqueString(10), RandomGenerator.GetRandomEnumValue<Severity>());

    [SetUp]
    public void SetUp()
    {
        ProjectSettingsSteps = new ProjectSettingsSteps(BrowserService, "Project Settings Page", _testProject.Code);
        ProjectRepositorySteps = new ProjectRepositorySteps(BrowserService, "Project Repository Page", _testProject.Code);
        ProjectDefectCreateSteps = new ProjectDefectCreateSteps(BrowserService, "Project Defect Create Page", _testProject.Code);
        ProjectsDashboardSteps = new ProjectsDashboardSteps(BrowserService, "Dashboard Page");
        ProjectDefectDashboardSteps =
            new ProjectDefectDashboardSteps(BrowserService, "Project Defect Dashboard Steps", _testProject.Code);
        ProjectDefectViewSteps =
            new ProjectDefectViewSteps(BrowserService, "Project Defect View steps", _testProject.Code);
        
        Authenticate();
        ProjectsDashboardSteps.CreateProject(_testProject)
            .OpenProjectsDashboardPage()
            .OpenProject(_testProject.Title);
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Adding a Defect On Project Test")]
    [AllureSubSuite("Project")]
    public void AddDefectOnProjectTest()
    {
        ProjectDefectCreateSteps.OpenProjectDefectCreatePage()
            .CreateDefect(_testDefect);
        ProjectDefectDashboardSteps.OpenDefectViewPage();
        var testDefect = ProjectDefectViewSteps.GetProjectDefect();
        
        Assert.That(testDefect, Is.EqualTo(_testDefect), "Defect Created should be as expected.");
    }
    
    [TearDown]
    public void TearDown()
    {
        ProjectsDashboardSteps.OpenProjectsDashboardPage()
            .DeleteProject(_testProject.Title);
        BrowserService.Browser.Quit();
    }
}