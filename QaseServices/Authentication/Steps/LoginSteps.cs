using NUnit.Allure.Attributes;
using QaseCore.Utilities;
using QaseServices.Authentication.Pages;
using QaseServices.Project.Models;

namespace QaseServices.Authentication.Steps;

public class LoginSteps
{
    private readonly LoginPage _loginPage;
    
    public LoginSteps(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    [AllureStep("Authenticating.")]
    public void Login(UserAuthenticationCredentials credentials)
    {
        Logger.Instance.Info("Authenticating.");
        _loginPage.OpenPage();
        _loginPage.InputEmail(credentials.Email);
        _loginPage.InputPassword(credentials.Password);
        _loginPage.LoginButtonClick();
    }
}