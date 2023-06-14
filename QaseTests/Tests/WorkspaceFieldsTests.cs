using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Workspace.Pages;
using QaseServices.Workspace.Steps;
using QaseTests.Utilities;

namespace QaseTests.Tests;

[AllureNUnit]
[AllureSuite("Workspace Fields Tests")]
public class WorkspaceFieldsTests : Test
{
    private WorkspaceFieldsPage WorkspaceFieldsPage {get; set; }
    private WorkspaceFieldsSteps WorkspaceFieldsSteps {get; set; }

    [SetUp]
    public void SetUp()
    {
        WorkspaceFieldsPage = new WorkspaceFieldsPage(BrowserService, "Workspace Fields Page");
        WorkspaceFieldsSteps = new WorkspaceFieldsSteps(WorkspaceFieldsPage);
        
        Authenticate();
    }
    
    [Test]
    [AllureTag("Acceptance")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Editing the Test Case Field Test")]
    [AllureSubSuite("Workspace")]
    public void EditTestCaseFieldTest()
    {
        var fieldIndex = RandomGenerator.RandomInt(9);
        
        WorkspaceFieldsSteps.OpenPage();
        var before = WorkspaceFieldsPage.GetFieldProjectsText(fieldIndex);
        WorkspaceFieldsSteps.EditEnableForAllProjects(fieldIndex)
            .OpenPage();
        var after = WorkspaceFieldsPage.GetFieldProjectsText(fieldIndex);
        
        Assert.That(after, Is.Not.EqualTo(before));
    }
    
    [TearDown]
    public void TearDown()
    {
        BrowserService.Browser.Quit();
    }
}