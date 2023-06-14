using System.Net;
using NUnit.Framework;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Models.ApiResponseModels;
using RestSharp;

namespace QaseServices.Project.Api;

public class ApiProjectCaseService
{
    private readonly RestClient _restClient;
    
    public ApiProjectCaseService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public async Task CreateProjectCase(ApiProjectCaseResponse testCase, string projectCode)
    { 
        var postRequest = new RestRequest();
        postRequest.Resource = $"/case/{projectCode}";
        postRequest.AddJsonBody(
            new {
                title = testCase.Result.Title,
                status = testCase.Result.Status,
                type = testCase.Result.Type,
                preconditions = testCase.Result.Preconditions,
                postconditions = testCase.Result.Postconditions,
                severity = testCase.Result.Severity,
                priority = testCase.Result.Priority,
                behavior = testCase.Result.Behavior,
                description = testCase.Result.Description,
                automation = testCase.Result.Automation
            });
        
        var response = await _restClient.ExecutePostAsync(postRequest);
        Logger.Instance.Debug($"Project case creation response: {response.StatusDescription}");
        Logger.Instance.Debug($"Project case creation response: {response.Content}");
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new AssertionException("Project case is not created!");
        }
    }
    
    public async Task<ApiProjectCaseResponse> GetProjectCase(string projectCode, int caseId)
    { 
        var postRequest = new RestRequest();
        postRequest.Resource = $"/case/{projectCode}/{caseId}";
        
        var response = await _restClient.ExecuteGetAsync<ApiProjectCaseResponse>(postRequest);
        Logger.Instance.Debug($"Project case get response: {response.StatusDescription}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new AssertionException("Project case get failed!");
        }

        return response.Data;
    }
}