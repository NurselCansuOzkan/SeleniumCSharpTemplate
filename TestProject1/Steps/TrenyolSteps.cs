using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject1.Pages;
using TestProject1.Helpers;

namespace TestProject1.Steps
{
     [Binding]
    public class TrenyolSteps
    {
        private readonly IWebDriver _driver;
        private readonly TrendyolPage _trendyolPage;

        public TrenyolSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["Driver"];
            _trendyolPage = new TrendyolPage(_driver);
        }

        [Given(@"Trendyol ana sayfayı aç")]
        public void GivenIHaveOpenedTheGoogleHomepage()
        {
            _trendyolPage.GoTo();
        }

        [When(@"Giriş butonuna tıkla")]
        public void WhenClickLoginButton()
        {
            _trendyolPage.ClickLoginButton();
        }

        [When(@"Eposta ve şifre gir")]
        public void WhenFillInputField(){
            _trendyolPage.FillInputField();
        }

        [When(@"Giriş yap butonuna tıkla")]
        public void WhenFillAfterClickLoginButton(){
            _trendyolPage.FillAfterClickLoginButton();
        }

        

        [Then(@"Başarılı girişi kontrol et '(.*)'")]
        public void ThenTheSearchResultsShouldContain(string searchTerm)
        {
            bool containsTerm = _trendyolPage.SearchResultsContain(searchTerm);
            if (!containsTerm)
            {
                CustomHelper.TakeScreenshot(_driver, "SearchResultsError");
            }
            Assert.IsTrue(containsTerm, $"The search results did not contain the term '{searchTerm}'.");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CustomHelper.QuitDriver(_driver);
        }
    }
}
