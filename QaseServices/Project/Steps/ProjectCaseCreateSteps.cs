using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectCaseCreateSteps
{
    private readonly ProjectCaseCreatePage _projectCaseCreatePage;

    public ProjectCaseCreateSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectCaseCreatePage = new ProjectCaseCreatePage(browserService, pageName, projectCode);
    }

    [AllureStep("Opening Project Case Create Page.")]
    public ProjectCaseCreateSteps OpenProjectCaseCreatePage()
    {
        Logger.Instance.Info("Opening Project Case Create Page.");
        _projectCaseCreatePage.OpenPage();

        return this;
    }
    
    [AllureStep("Creating new case.")]
    public ProjectCaseCreateSteps CreateCase(ProjectTestCase testCase)
    {
        Logger.Instance.Info("Creating new case.");
        _projectCaseCreatePage.InputCaseTitle(testCase.Title);
        _projectCaseCreatePage.ClickSaveAndCreateCase();
        
        return this;
    }
}