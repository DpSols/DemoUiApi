using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Api;
using QaseServices.Project.Models;
using QaseTests.Utilities;

namespace QaseTests.ApiTests;

[AllureNUnit]
[AllureSuite("API Create Project Tests")]
public class ApiProjectCreateTests : ApiTest
{
    private ApiProjectService ApiProjectService { get; set; }

    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(8).ToUpper());

    [SetUp]
    public void SetUpServices()
    {
        ApiProjectService = new ApiProjectService(RestClient);
    }
    
    [Test]
    [AllureTag("Integration")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Create Project API Test")]
    [AllureSubSuite("Project")]
    public async Task CreateProjectTest()
    {
        await ApiProjectService.CreateProject(_testProject);
        var responseProject = await ApiProjectService.GetProject(_testProject.Code);
        
        Assert.That(responseProject, Is.EqualTo(_testProject), "Project created should be the same as expected.");
    }

    [TearDown]
    public async Task DeleteProject()
    {
        await ApiProjectService.DeleteProject(_testProject.Code);
    }
}