using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Models;
using QaseServices.Project.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Project Case Tests")]
public class ProjectCaseTests : Test
{
    private ProjectCaseCreateSteps ProjectCaseCreateSteps {get; set; }
    private ProjectRepositorySteps ProjectRepositorySteps {get; set; }
    private ProjectsDashboardSteps ProjectsDashboardSteps {get; set; }
    private ProjectSettingsSteps ProjectSettingsSteps {get; set; }
    
    private readonly ProjectTestCase _testCase = new ProjectTestCase(RandomGenerator.RandomUniqueString(10));
    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(3).ToUpper());
    
    [SetUp]
    public void SetUp()
    {
        ProjectCaseCreateSteps = new ProjectCaseCreateSteps(BrowserService, "Project Case Create Page", _testProject.Code);
        ProjectRepositorySteps = new ProjectRepositorySteps(BrowserService, "Project Repository Page", _testProject.Code);
        ProjectsDashboardSteps = new ProjectsDashboardSteps(BrowserService, "Dashboard Page");
        ProjectSettingsSteps = new ProjectSettingsSteps(BrowserService, "Project Settings Page", _testProject.Code);
        
        Authenticate();
        ProjectsDashboardSteps.CreateProject(_testProject)
            .OpenProjectsDashboardPage()
            .OpenProject(_testProject.Title);
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Adding a Test Case Test")]
    [AllureSubSuite("Project")]
    public void AddTestCaseTest()
    {
        ProjectCaseCreateSteps.OpenProjectCaseCreatePage()
            .CreateCase(_testCase);
        var testCases = ProjectRepositorySteps.GetTestCases();
        var isTestCasesCreated = testCases.Any(testCase => testCase.Equals(_testCase));
        
        Assert.That(isTestCasesCreated, Is.True, "Test case should be in the project repository.");
    }
    
    [TearDown]
    public void TearDown()
    {
        ProjectsDashboardSteps.OpenProjectsDashboardPage()
            .DeleteProject(_testProject.Title);
        
        BrowserService.Browser.Quit();
    }
}