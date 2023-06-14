using OpenQA.Selenium;
using QaseCore.BrowserFactory;

namespace QaseServices;

public static class AlertHandleHelper
{
    public static void HandleAlert(IBrowser browser)
    {
        try
        {
            IAlert alert = browser.WebDriverWait.Until(drv =>
            {
                try
                {
                    return drv.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            }) ?? throw new InvalidOperationException("Object is null here.");
            alert.Accept();
        }
        catch (WebDriverTimeoutException)
        {
            
        }
    }
}