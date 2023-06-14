using Bogus;
using QaseServices.Project.Models;
using QaseServices.Project.Models.ApiResponseModels;

namespace QaseTests.Entities.RandomEntities;

public class ProjectTestCaseFactory
{
    public ProjectTestCase GetNewProjectTestCase()
    {
        var guidString = Guid.NewGuid().ToString();
        var testCase = new ProjectTestCase(guidString);

        return testCase;
    }

    public ApiProjectCaseResponse GetProjectTestCase()
    {
        var faker = new Faker();

        var fakeResult = new TestResult
        {
            Title = faker.Lorem.Sentence(),
            Description = faker.Lorem.Paragraph(),
            Preconditions = faker.Lorem.Paragraph(),
            Postconditions = faker.Lorem.Paragraph(),
            Severity = faker.Random.Int(1, 6),
            Priority = faker.Random.Int(1, 3),
            Type = faker.Random.Int(1, 10),
            Behavior = faker.Random.Int(1, 3),
            Automation = faker.Random.Int(0, 3),
            IsFlaky = faker.Random.Bool(),
            Status = faker.Random.Int(0, 3)
        };
        
        var fakeApiObj = new ApiProjectCaseResponse
        {
            Status = faker.Random.Bool(),
            Result = fakeResult
        };
        
        return fakeApiObj;
    }
}