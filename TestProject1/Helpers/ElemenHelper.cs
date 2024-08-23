using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1.Helpers
{
    public static class ElementHelper
    {
        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            IWebElement element = null;
             var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            try
            {
                element = wait.Until(drv => drv.FindElement(by));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element not found: {by}");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timed out waiting for element: {by}");
            }

            return element;
        }

        public static void ClickElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var element = FindElement(driver, by, timeoutInSeconds);

            if (element != null)
            {
                try
                {
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    Console.WriteLine($"Element click intercepted: {by}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error clicking element: {by} - {ex.Message}");
                }
            }
        }

        public static void EnterText(IWebDriver driver, By by, string text, int timeoutInSeconds = 10)
        {
            var element = FindElement(driver, by, timeoutInSeconds);

            if (element != null)
            {
                try
                {
                    element.Clear();
                    element.SendKeys(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error entering text into element: {by} - {ex.Message}");
                }
            }
        }

        public static string GetElementText(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var element = FindElement(driver, by, timeoutInSeconds);

            return element != null ? element.Text : string.Empty;
        }
    }
}
