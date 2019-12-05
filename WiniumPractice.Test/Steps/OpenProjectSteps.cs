using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WiniumPractice.Test.Steps
{
    [Binding]
    public class OpenProjectSteps
    {
        RemoteWebDriver driver;
        IWebElement mainWindow;
        IWebElement projectCenterWindow;

        [BeforeScenario("open-project")]
        public void BeforeScenario()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:\Program Files (x86)\M4Solutions\M4Solutions.exe");
            this.driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

        [AfterScenario("open-project")]
        public void AfterScenario()
        {
            this.driver.Close();
        }

        [Given(@"that M4 has just opened")]
        public void GivenThatMHasJustOpened()
        {
            this.mainWindow = this.driver.FindElementById("MDIForm1");
            this.projectCenterWindow = mainWindow.FindElement(By.Id("ProjectCenter"));
        }

        [When(@"the user picks a project from his filesystem")]
        public void WhenTheUserPicksAProjectFromHisFilesystem()
        {
            var btnPickProject = this.projectCenterWindow.FindElement(By.Id("btnPickProject"));
            btnPickProject.Click();

            var openDialog = this.projectCenterWindow.FindElement(By.ClassName("#32770"));
            var filepathTextbox = openDialog.FindElement(By.Id("1148"));

            var filepath = @"E:\clients\mapcom\M4 Regression Test Automation\Test Project\Diversicom\ARVIG.prj";
            filepathTextbox.SendKeys(filepath);

            var cancelButton = openDialog.FindElement(By.Name("Cancel"));
            cancelButton.Click();
        }

        [Then(@"the project is opened")]
        public void ThenTheProjectIsOpened()
        {
            var cancelButton = this.projectCenterWindow.FindElement(By.Name("Cancel"));
            cancelButton.Click();
        }

    }
}
