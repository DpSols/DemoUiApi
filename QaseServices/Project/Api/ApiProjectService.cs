using System.Net;
using NUnit.Framework;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using RestSharp;

namespace QaseServices.Project.Api;

public class ApiProjectService
{
    private readonly RestClient _restClient;
    
    public ApiProjectService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public async Task CreateProject(TestProject project)
    { 
        var postRequest = new RestRequest();
        postRequest.Resource = "/project";
        postRequest.AddJsonBody(
            new {
                title = project.Title,
                code = project.Code
            });
        
        var response = await _restClient.ExecutePostAsync(postRequest);
        Logger.Instance.Debug($"Project creation response: {response.StatusDescription}");
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new AssertionException("Project is not created!");
        }
    }
    
    public async Task<TestProject> GetProject(string code)
    { 
        var getRequest = new RestRequest();
        getRequest.Resource = $"/project/{code}";
        
        var response = await _restClient.ExecuteGetAsync<JsonResponse>(getRequest);
        Logger.Instance.Debug($"Project get response: {response.StatusDescription}");
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return new TestProject();
        }
        
        var project = new TestProject(response.Data.Result.Title, response.Data.Result.Code);
        
        return project;
    }

    public async Task DeleteProject(string code)
    {
        var getRequest = new RestRequest($"/project/{code}", Method.Delete);
        getRequest.Resource = $"/project/{code}";
        
        var response = await _restClient.ExecuteAsync(getRequest);
        
        Logger.Instance.Debug($"Project delete response: {response.StatusDescription}");
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new AssertionException("Project is not created!");
        }
    }
}