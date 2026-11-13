using ConsoleSelenium.Tests.Pages;
using ConsoleSelenium.Tests.Support;
using OpenQA.Selenium;
using static ConsoleSelenium.WebFormConstants;

namespace ConsoleSelenium.Tests;

[TestClass]
public sealed class WebFormularioDesafioTest
{
    private IWebDriver _driver = null!;
    private WebFormPage _page = null!;

    [TestInitialize]
    public void Setup()
    {
        _driver = WebDriverFactory.CreateChrome();
        _page = new WebFormPage(_driver).Open();
    }

    [TestCleanup]
    public void TearDown()
    {
        _driver?.Quit();
    }

    [TestMethod]
    public void Exercicio1_CadastroCompleto_DeveExibirMensagemDeSucesso()
    {
        _page.FillText("Seu Nome Completo")
             .FillPassword("S3nh@Segura!2026")
             .FillTextarea("Tenho experiência com testes automatizados usando C#, MSTest e Selenium WebDriver.");

        Assert.AreEqual(ReadonlyDefaultValue, _page.ReadonlyValue);

        Assert.AreEqual(SuccessMessage, _page.SubmitAndGetMessage());
    }

    [TestMethod]
    public void Exercicio2_DropdownEDatalist_DeveEnviarSemExcecoes()
    {
        _page.SelectDropdownByText("Two");
        Assert.AreEqual("2", _page.Dropdown.SelectedOption.GetDomProperty("value"));

        _page.FillDatalist("Seattle");
        Assert.AreEqual("Seattle", _page.DatalistValue);

        Assert.AreEqual(SuccessMessage, _page.SubmitAndGetMessage());
    }

    [TestMethod]
    public void Exercicio3_CheckboxRadioEColorPicker_DeveEnviarComSucesso()
    {
        Assert.IsTrue(_page.IsCheckbox1Checked, "O checkbox 1 deveria vir marcado por padrão.");

        _page.CheckCheckbox2();
        Assert.IsTrue(_page.IsCheckbox2Checked, "O checkbox 2 deveria estar marcado.");

        _page.SelectRadio2();
        Assert.IsTrue(_page.IsRadio2Selected, "O radio 2 deveria estar selecionado.");

        const string novaCor = "#ff0000";
        _page.SetColor(novaCor);
        Assert.AreEqual(novaCor, _page.ColorValue);

        Assert.AreEqual(SuccessMessage, _page.SubmitAndGetMessage());
    }
}
