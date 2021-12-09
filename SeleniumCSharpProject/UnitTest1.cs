using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpProject.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpProject
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver(@"C:\driver\", options);
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");
            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almond");
            Assert.Pass();
        }

        [Test]
        public void LoginTest()
        {

            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();

            homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword("admin", "password");
            loginPage.ClickLogin();
            Assert.That(homePage.IsLogOffExist, Is.True, "Log off button did not displayed");
        }
    }
}