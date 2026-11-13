using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Tests.Support;

/// <summary>
/// Cria instâncias de WebDriver configuradas para os testes.
/// Defina a variável de ambiente HEADLESS=false para ver o navegador abrindo.
/// </summary>
public static class WebDriverFactory
{
    public static IWebDriver CreateChrome()
    {
        var options = new ChromeOptions();

        var headless = Environment.GetEnvironmentVariable("HEADLESS");
        if (!string.Equals(headless, "false", StringComparison.OrdinalIgnoreCase))
        {
            options.AddArgument("--headless=new");
        }

        options.AddArgument("--window-size=1366,768");

        var driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        return driver;
    }
}
