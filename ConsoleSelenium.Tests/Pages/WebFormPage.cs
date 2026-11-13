using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static ConsoleSelenium.WebFormConstants;

namespace ConsoleSelenium.Tests.Pages;

/// <summary>
/// Page Object do formulário https://www.selenium.dev/selenium/web/web-form.html.
/// </summary>
public class WebFormPage(IWebDriver driver)
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    private IWebElement TextInput => driver.FindElement(By.Name(Fields.Text));
    private IWebElement PasswordInput => driver.FindElement(By.Name(Fields.Password));
    private IWebElement Textarea => driver.FindElement(By.Name(Fields.Textarea));
    private IWebElement ReadonlyInput => driver.FindElement(By.Name(Fields.Readonly));
    private IWebElement SelectInput => driver.FindElement(By.Name(Fields.Select));
    private IWebElement DatalistInput => driver.FindElement(By.Name(Fields.Datalist));
    private IWebElement ColorInput => driver.FindElement(By.Name(Fields.Color));
    private IWebElement Checkbox1 => driver.FindElement(By.Id(Fields.Checkbox1));
    private IWebElement Checkbox2 => driver.FindElement(By.Id(Fields.Checkbox2));
    private IWebElement Radio2 => driver.FindElement(By.Id(Fields.Radio2));
    private IWebElement SubmitButton => driver.FindElement(By.CssSelector("button[type='submit']"));

    public WebFormPage Open()
    {
        driver.Navigate().GoToUrl(Url);
        return this;
    }

    public WebFormPage FillText(string value) => Type(TextInput, value);
    public WebFormPage FillPassword(string value) => Type(PasswordInput, value);
    public WebFormPage FillTextarea(string value) => Type(Textarea, value);
    public WebFormPage FillDatalist(string value) => Type(DatalistInput, value);

    public string ReadonlyValue => ReadonlyInput.GetDomProperty("value") ?? string.Empty;
    public string DatalistValue => DatalistInput.GetDomProperty("value") ?? string.Empty;

    public SelectElement Dropdown => new(SelectInput);

    public WebFormPage SelectDropdownByText(string text)
    {
        Dropdown.SelectByText(text);
        return this;
    }

    public bool IsCheckbox1Checked => Checkbox1.Selected;
    public bool IsCheckbox2Checked => Checkbox2.Selected;
    public bool IsRadio2Selected => Radio2.Selected;

    public WebFormPage CheckCheckbox2()
    {
        if (!Checkbox2.Selected) Checkbox2.Click();
        return this;
    }

    public WebFormPage SelectRadio2()
    {
        Radio2.Click();
        return this;
    }

    public string ColorValue => ColorInput.GetDomProperty("value") ?? string.Empty;

    /// <summary>
    /// O seletor de cor nativo não aceita SendKeys de forma confiável,
    /// então o valor é definido via JavaScript e o evento "change" é disparado.
    /// </summary>
    public WebFormPage SetColor(string hexColor)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript(
            "arguments[0].value = arguments[1];" +
            "arguments[0].dispatchEvent(new Event('input', { bubbles: true }));" +
            "arguments[0].dispatchEvent(new Event('change', { bubbles: true }));",
            ColorInput, hexColor);
        return this;
    }

    /// <summary>Envia o formulário e retorna o texto da mensagem da página de sucesso.</summary>
    public string SubmitAndGetMessage()
    {
        SubmitButton.Click();

        var wait = new WebDriverWait(driver, Timeout);
        var message = wait.Until(d => d.FindElement(By.Id(Fields.SuccessMessageId)));
        return message.Text;
    }

    private WebFormPage Type(IWebElement element, string value)
    {
        element.Clear();
        element.SendKeys(value);
        return this;
    }
}
