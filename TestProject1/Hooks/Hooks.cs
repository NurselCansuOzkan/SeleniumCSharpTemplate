using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject1.Helpers;


namespace TestProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;


        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = CustomHelper.InitializeDriver();
            _driver.Manage().Window.Maximize();

        }

        [BeforeScenario]
        public void SetUpScenario()
        {
            // Set the driver for the current scenario
            ScenarioContext.Current["Driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                try
                {
                    CustomHelper.TakeScreenshot(_driver, _scenarioContext.ScenarioInfo.Title.Replace(" ", "_"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error taking screenshot: {ex.Message}");
                }
                finally
                {
                   //CustomHelper.QuitDriver(_driver);
                }
            }
        }
    }
}
