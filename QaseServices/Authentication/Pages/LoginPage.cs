using OpenQA.Selenium;
using QaseCore.BrowserFactory;
using QaseCore.PageForms;

namespace QaseServices.Authentication.Pages;

public class LoginPage : BaseForm
{
    private readonly By _emailInputLocator = By.CssSelector("#inputEmail");
    private readonly By _passwordInputLocator = By.CssSelector("#inputPassword");
    private readonly By _loginButtonLocator = By.CssSelector("#btnLogin");

    private IWebElement EmailInput =>
        Browser.WebDriver.FindElement(_emailInputLocator);
    private IWebElement PasswordInput =>
        Browser.WebDriver.FindElement(_passwordInputLocator);
    private IWebElement LoginButton =>
        Browser.WebDriver.FindElement(_loginButtonLocator);
    
    public LoginPage(IBrowserService browserService, string pageName) : base(browserService, pageName)
    {
    }
    
    protected override string BaseUrl => "https://app.qase.io";
    protected override string UrlPath => "/login";

    public void InputEmail(string email)
    {
        EmailInput.SendKeys(email);
    }
    
    public void InputPassword(string password)
    {
        PasswordInput.SendKeys(password);
    }
    
    public void LoginButtonClick()
    {
        LoginButton.Click();
    }
}