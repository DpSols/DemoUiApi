using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Models;
using QaseServices.Project.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Project Plan Tests")]
public class ProjectPlanTests : Test
{
    private ProjectCaseCreateSteps ProjectCaseCreateSteps {get; set; }
    private ProjectsDashboardSteps ProjectsDashboardSteps {get; set; }
    private ProjectPlanCreateSteps ProjectPlanCreateSteps {get; set; }
    private ProjectPlanSteps ProjectPlanSteps {get; set; }
    
    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(4).ToUpper());
    private readonly ProjectTestCase _testCase = new ProjectTestCase(RandomGenerator.RandomUniqueString(10));
    private readonly ProjectPlan _projectPlan = new ProjectPlan(RandomGenerator.RandomUniqueString(10));
    
    [SetUp]
    public void SetUp()
    {
        ProjectCaseCreateSteps = new ProjectCaseCreateSteps(BrowserService, "Project Case Create Page", _testProject.Code);
        ProjectsDashboardSteps = new ProjectsDashboardSteps(BrowserService, "Dashboard Page");
        ProjectPlanCreateSteps = new ProjectPlanCreateSteps(BrowserService, "Project Plan Create Page", _testProject.Code);
        ProjectPlanSteps = new ProjectPlanSteps(BrowserService, "Project Plan Page", _testProject.Code);
        
        Authenticate();
        ProjectsDashboardSteps.CreateProject(_testProject)
            .OpenProjectsDashboardPage()
            .OpenProject(_testProject.Title);
        
        ProjectCaseCreateSteps.OpenProjectCaseCreatePage()
            .CreateCase(_testCase);
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Adding a Test Plan Test")]
    [AllureSubSuite("Project")]
    public void AddTestPlanTest()
    {
        ProjectPlanSteps.OpenProjectPlanPage()
            .ClickCreateLink();
        ProjectPlanCreateSteps.CreatePlan(_projectPlan);
        var plans = ProjectPlanSteps.GetProjectPlans();
        
        Assert.That(plans, Does.Contain(_projectPlan), "Plan created should be on the plans page.");
    }

    [TearDown]
    public void TearDown()
    {
        ProjectsDashboardSteps.OpenProjectsDashboardPage()
            .DeleteProject(_testProject.Title);
        BrowserService.Browser.Quit();
    }
}