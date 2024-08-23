using OpenQA.Selenium;
using TestProject1.Helpers;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Pages
{public class TrendyolPage
    {
        string username = "";
        string password = "";
        private readonly IWebDriver _driver;
        private readonly By searchBox = By.Name("q");
        private readonly By searchButton = By.Name("btnK");
        private readonly By acceptCookie = By.CssSelector("#onetrust-accept-btn-handler");
        private readonly By loginButton = By.CssSelector("div[class='link account-user'] p[class='link-text']");
        private readonly By inputEmailField = By.CssSelector("#login-email");

        private readonly By inputPasswordField = By.CssSelector("#login-password-input");
        private readonly By submitLoginBtn = By.CssSelector("button[type='submit']");
        private readonly By hesabimBtn = By.CssSelector(".i-user-orange.hover-icon");
        
        private readonly By siparisText = By.CssSelector("div[class='header-bar'] h1");


        
        


        public TrendyolPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.trendyol.com/");
        }

        public void ClickLoginButton(){
            ElementHelper.FindElement(_driver,acceptCookie);
            ElementHelper.ClickElement(_driver,acceptCookie);
            ElementHelper.FindElement(_driver, loginButton);
            ElementHelper.ClickElement(_driver,loginButton);
        }

        public void FillInputField(){
            ElementHelper.FindElement(_driver,inputEmailField);
            ElementHelper.ClickElement(_driver,inputEmailField);
            ElementHelper.EnterText(_driver,inputEmailField, username);
            ElementHelper.FindElement(_driver,inputPasswordField);
            ElementHelper.ClickElement(_driver,inputPasswordField);
            ElementHelper.EnterText(_driver,inputPasswordField, password);

        }

        public void FillAfterClickLoginButton(){
            ElementHelper.FindElement(_driver,submitLoginBtn);
            ElementHelper.ClickElement(_driver,submitLoginBtn);
            Thread.Sleep(2000);

            ElementHelper.FindElement(_driver,loginButton,20);
            ElementHelper.ClickElement(_driver,loginButton,20);
        }
        

        public bool SearchResultsContain(string searchTerm)
        {
            
            var result =ElementHelper.FindElement(_driver,siparisText,40);
            Console.WriteLine("result---------------",result.Text );
            return result.Text.Contains(searchTerm);
        }

    }
}
