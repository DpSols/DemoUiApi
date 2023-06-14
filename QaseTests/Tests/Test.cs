using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using QaseCore.BrowserFactory;
using QaseServices.Authentication.Pages;
using QaseServices.Authentication.Steps;
using QaseTests.AppConfigurations;
using QaseTests.Entities;

namespace QaseTests.Tests;

[Parallelizable(ParallelScope.Fixtures)]
public abstract class Test
{
    private ServiceProvider Services => DiConfigurations.ConfigureServices().BuildServiceProvider();
    protected IBrowserService BrowserService => Services.GetService(typeof(IBrowserService)) as IBrowserService;

    private LoginPage LoginPage {get; set; }
    private LoginSteps LoginSteps {get; set; }
    
    protected void Authenticate()
    {
        LoginPage = new LoginPage(BrowserService, "Login Page");
        LoginSteps = new LoginSteps(LoginPage);
        
        LoginSteps.Login(AuthenticationCredentials.BasicCredentials);
    }
}