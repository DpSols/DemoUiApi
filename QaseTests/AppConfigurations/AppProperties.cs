using AngleSharp.Text;
using Microsoft.Extensions.Configuration;
using QaseCore.BrowserFactory;
using QaseCore.Utilities;
using QaseTests.Utilities;

namespace QaseTests.AppConfigurations;

public static class AppProperties
{
    private static string[] _chromeOptions;
    private static BrowserNames _browserName;
    private static string _baseUrl;
    private static string _token;
    private static string _apiUrl;
    private static readonly object _lock = new object();
    
    public static string[] ChromeOptions
    {
        get
        {
            if (_chromeOptions == null)
            {
                lock (_lock)
                {
                    if (_chromeOptions == null)
                    {
                        _chromeOptions = ConfigurationsReader.Configuration.GetSection("ChromeOptions").Get<string[]>();
                        Logger.Instance.Debug($"Applying chrome options: {string.Join(", ", _chromeOptions)}");
                        return _chromeOptions;
                    }
                }
            }
            
            return _chromeOptions;
        }
    }

    public static BrowserNames BrowserName
    {
        get
        {
            if (_browserName == 0)
            {
                lock (_lock)
                {
                    if (_browserName == 0)
                    {
                        var _browserValues = ConfigurationsReader.Configuration.GetValue<string>("BrowserName");
                        Logger.Instance.Debug($"Using {_browserValues} browser.");
                        _browserName = Enum.Parse<BrowserNames>(_browserValues);
                        return _browserName;
                    }
                }
            }

            return _browserName;
        }
    }

    public static string BaseUrl
    {
        get
        {
            if (_baseUrl == null)
            {
                lock (_lock)
                {
                    if (_baseUrl == null)
                    {
                        _baseUrl = ConfigurationsReader.Configuration.GetValue<string>("Url");
                        Logger.Instance.Debug($"BaseUrl is {_baseUrl}.");
                        return _baseUrl;
                    }
                }
            }

            return _baseUrl;
        }
    }
    
    public static string Token
    {
        get
        {
            if (_token == null)
            {
                lock (_lock)
                {
                    if (_token != null) return _token;
                    
                    _token = ConfigurationsReader.Configuration.GetValue<string>("Token");
                    Logger.Instance.Debug($"Token is {_token}.");
                    return _token;
                }
            }

            return _token;
        }
    }
    public static string ApiUrl
    {
        get
        {
            if (_apiUrl == null)
            {
                lock (_lock)
                {
                    if (_apiUrl != null) return _apiUrl;
                    
                    _apiUrl = ConfigurationsReader.Configuration.GetValue<string>("ApiUrl");
                    Logger.Instance.Debug($"API base url is {_apiUrl}.");
                    return _apiUrl;
                }
            }

            return _apiUrl;
        }
    }
}