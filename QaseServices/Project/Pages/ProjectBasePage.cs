using QaseCore.BrowserFactory;
using QaseCore.PageForms;

namespace QaseServices.Project.Pages;

public abstract class ProjectBasePage : BaseForm
{
    protected ProjectBasePage(IBrowserService browserService, string pageName, string projectCode) : base(browserService, pageName)
    {
        ProjectCode = projectCode;
    }
    
    protected override string BaseUrl => "https://app.qase.io";
    protected override string UrlPath => $"/project/{ProjectCode}";
    protected string ProjectCode { get; }
}