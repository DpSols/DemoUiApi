using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Api;
using QaseServices.Project.Models;
using QaseTests.Utilities;

namespace QaseTests.ApiTests;

[AllureNUnit]
[AllureSuite("API Delete Project Tests")]
public class ApiProjectDeleteTests : ApiTest
{
    private ApiProjectService ApiProjectService { get; set; }

    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(8).ToUpper());

    [SetUp]
    public async Task SetUpServices()
    {
        ApiProjectService = new ApiProjectService(RestClient);
        
        await ApiProjectService.CreateProject(_testProject);
    }
    
    [Test]
    [AllureTag("Integration")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("Delete Project API Test")]
    [AllureSubSuite("Project")]
    public async Task DeleteProjectTest()
    {
        await ApiProjectService.DeleteProject(_testProject.Code);
        var responseProject = await ApiProjectService.GetProject(_testProject.Code);
        
        Assert.That(responseProject, Is.EqualTo(new TestProject()), "The service should return empty project.");
    }
}