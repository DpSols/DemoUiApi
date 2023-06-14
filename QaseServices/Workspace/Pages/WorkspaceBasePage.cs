using QaseCore.BrowserFactory;
using QaseCore.PageForms;

namespace QaseServices.Workspace.Pages;

public abstract class WorkspaceBasePage : BaseForm
{
    protected WorkspaceBasePage(IBrowserService browser, string pageName) : base(browser, pageName)
    {
    }

    protected override string BaseUrl => "https://app.qase.io";
    protected override string UrlPath => "/workspace";
}