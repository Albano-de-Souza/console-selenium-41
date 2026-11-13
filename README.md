# console-selenium-41

Automação do formulário [Selenium Web Form](https://www.selenium.dev/selenium/web/web-form.html) com **C#**, **.NET 10**, **MSTest** e **Selenium WebDriver**.

## Estrutura

```
ConsoleSelenium41.slnx
├── ConsoleSelenium/              # Console App: constantes (URL, localizadores, textos esperados)
└── ConsoleSelenium.Tests/        # MSTest + Selenium.WebDriver + Selenium.Support
    ├── Pages/WebFormPage.cs      # Page Object do formulário
    ├── Support/WebDriverFactory.cs
    └── WebFormularioDesafioTest.cs
```

## Cenários

| Teste | O que valida |
|---|---|
| `Exercicio1_CadastroCompleto_...` | Preenche text, password e textarea; valida o readonly = "Readonly input"; envia e valida "Received!" |
| `Exercicio2_DropdownEDatalist_...` | `SelectElement` seleciona "Two" (valor `2`); datalist recebe "Seattle"; envia sem exceções |
| `Exercicio3_CheckboxRadioEColorPicker_...` | Checkbox 1 marcado por padrão; marca checkbox 2; seleciona radio 2; altera a cor; envia com sucesso |

## Como executar

Pré-requisitos: .NET 10 SDK e Google Chrome (o driver é baixado automaticamente pelo Selenium Manager).

```bash
dotnet test
```

Para ver o navegador abrindo (sem headless):

```powershell
$env:HEADLESS="false"; dotnet test
```
