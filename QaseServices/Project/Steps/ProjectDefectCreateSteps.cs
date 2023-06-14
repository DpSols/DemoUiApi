using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseServices.Project.Models;
using QaseServices.Project.Pages;

namespace QaseServices.Project.Steps;

public class ProjectDefectCreateSteps
{
    private readonly ProjectDefectCreatePage _projectDefectCreatePage;
    
    public ProjectDefectCreateSteps(IBrowserService browserService, string pageName, string projectCode)
    {
        _projectDefectCreatePage = new ProjectDefectCreatePage(browserService, pageName, projectCode);
    }

    [AllureStep("Opening Project Defect Create Page.")]
    public ProjectDefectCreateSteps OpenProjectDefectCreatePage()
    {
        Logger.Instance.Info("Opening Project Defect Create Page.");
        _projectDefectCreatePage.OpenPage();

        return this;
    }

    [AllureStep("Creating a new defect.")]
    public ProjectDefectCreateSteps CreateDefect(TestDefect defect)
    {
        Logger.Instance.Info("Creating a new defect.");
        _projectDefectCreatePage.InputDefectTitle(defect.DefectTitle);
        _projectDefectCreatePage.InputDefectActualResult(defect.DefectActualResult);
        _projectDefectCreatePage.ClickSeverityFieldButton();
        _projectDefectCreatePage.InputSeverity(defect.SeverityLvl.ToString());
        _projectDefectCreatePage.InputSeverity(Keys.Enter);
        _projectDefectCreatePage.ClickDefectSubmitButton();
        
        return this;
    }
}