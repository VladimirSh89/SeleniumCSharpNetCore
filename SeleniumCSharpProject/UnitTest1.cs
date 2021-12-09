using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpProject.Pages;

namespace SeleniumCSharpProject
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(@"C:\driver\");
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
            Driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();

            homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword("admin", "password");
            loginPage.ClickLogin();
            Assert.That(homePage.IsLogOffExist, Is.True, "Log off button did not displayed");
        }
    }
}