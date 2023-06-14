using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using QaseServices.Project.Api;
using QaseServices.Project.Models;
using QaseServices.Project.Models.ApiResponseModels;
using QaseTests.Entities.RandomEntities;
using QaseTests.Utilities;

namespace QaseTests.ApiTests;

[AllureNUnit]
[AllureSuite("API Project Case Tests")]
public class ApiProjectTestCaseTests : ApiTest
{
    private ApiProjectService ApiProjectService { get; set; }
    private ApiProjectCaseService ApiProjectCaseService { get; set; }
    private ApiProjectCaseResponse ApiProjectCaseResponse { get; set; }

    private readonly TestProject _testProject =
        new TestProject(RandomGenerator.RandomUniqueString(10), RandomGenerator.RandomUniqueString(3).ToUpper());
    
    [SetUp]
    public async Task SetUpServices()
    {
        ApiProjectService = new ApiProjectService(RestClient);
        ApiProjectCaseService = new ApiProjectCaseService(RestClient);
        ApiProjectCaseResponse = new ProjectTestCaseFactory().GetProjectTestCase();
        await ApiProjectService.CreateProject(_testProject);
    }

    [Test]
    [AllureTag("Integration")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Nodirbek Nematullaev")]
    [AllureDescription("API Create Project Test Case.")]
    [AllureSubSuite("Project")]
    public async Task CreateProjectCaseTest()
    {
        // RED Test
        await ApiProjectCaseService.CreateProjectCase(ApiProjectCaseResponse, _testProject.Code);
        var responseTestCase = await ApiProjectCaseService.GetProjectCase(_testProject.Code, 1);
        
        Assert.That(responseTestCase, Is.EqualTo(ApiProjectCaseResponse), "Case created should be equal to object expected.");
    }
    
    [TearDown]
    public async Task CleanUp()
    {
        await ApiProjectService.DeleteProject(_testProject.Code);
    }
}