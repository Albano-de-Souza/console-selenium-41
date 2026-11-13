namespace ConsoleSelenium;

/// <summary>
/// Centraliza URL, localizadores e textos esperados do formulário web de exemplo do Selenium.
/// </summary>
public static class WebFormConstants
{
    public const string Url = "https://www.selenium.dev/selenium/web/web-form.html";

    public const string SuccessMessage = "Received!";
    public const string ReadonlyDefaultValue = "Readonly input";

    public static class Fields
    {
        public const string Text = "my-text";
        public const string Password = "my-password";
        public const string Textarea = "my-textarea";
        public const string Readonly = "my-readonly";
        public const string Select = "my-select";
        public const string Datalist = "my-datalist";
        public const string Color = "my-colors";
        public const string Checkbox1 = "my-check-1";
        public const string Checkbox2 = "my-check-2";
        public const string Radio2 = "my-radio-2";
        public const string SuccessMessageId = "message";
    }
}
