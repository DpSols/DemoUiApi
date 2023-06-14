// using RestSharp;
//
// namespace QaseServices.Project.Api;
//
// public class ApiProjectPlanService
// {
//     private readonly RestClient _restClient;
//     
//     public ApiProjectPlanService(RestClient restClient)
//     {
//         _restClient = restClient;
//     }
//     
//     public async Task CreateProjectCase(ApiProjectCaseResponse testCase, string projectCode)
//     { 
//         var postRequest = new RestRequest();
//         postRequest.Resource = $"/case/{projectCode}";
//         postRequest.AddJsonBody(
//             new {
//                 title = testCase.Result.Title,
//                 status = testCase.Result.Status,
//                 type = testCase.Result.Type,
//                 preconditions = testCase.Result.Preconditions,
//                 postconditions = testCase.Result.Postconditions,
//                 severity = testCase.Result.Severity,
//                 priority = testCase.Result.Priority,
//                 behavior = testCase.Result.Behavior,
//                 description = testCase.Result.Description,
//                 automation = testCase.Result.Automation
//             });
//         
//         var response = await _restClient.ExecutePostAsync(postRequest);
//         Logger.Instance.Debug($"Project case creation response: {response.StatusDescription}");
//         Logger.Instance.Debug($"Project case creation response: {response.Content}");
//         
//         if (response.StatusCode != HttpStatusCode.OK)
//         {
//             throw new AssertionException("Project case is not created!");
//         }
//     }
// }