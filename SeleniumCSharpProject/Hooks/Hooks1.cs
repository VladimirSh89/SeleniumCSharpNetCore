using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpProject.Hooks
{
    [Binding]
    public sealed class Hooks1 : DriverHelper
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver(@"C:\driver\", options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}