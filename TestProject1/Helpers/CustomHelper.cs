using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.IO;

namespace TestProject1.Helpers
{
    public static class CustomHelper
    {
        private static string GetProjectRootDirectory()
        {
            // Projenin kök dizinine git
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectRootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            return projectRootDirectory;
        }

        public static IWebDriver InitializeDriver()
        {
            var projectRootDirectory = GetProjectRootDirectory();
            var relativePath = Path.Combine("Driver", "chromedriver-mac-arm64", "chromedriver");
            var chromeDriverPath = Path.Combine(projectRootDirectory, relativePath);

            // Yolu kontrol edin
            Console.WriteLine("Computed Path: " + chromeDriverPath);
            Console.WriteLine("Directory Exists: " + Directory.Exists(Path.GetDirectoryName(chromeDriverPath)));
            Console.WriteLine("File Exists: " + File.Exists(chromeDriverPath));

            if (!File.Exists(chromeDriverPath))
            {
                throw new FileNotFoundException("Chromedriver file not found.", chromeDriverPath);
            }

            var options = new ChromeOptions();
            var driver = new ChromeDriver(chromeDriverPath, options);

            return driver;
        }

        public static void TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver cannot be null.");
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var projectRootDirectory = GetProjectRootDirectory();
            var relativePath = Path.Combine("Screenshots", $"{screenshotName}.png");
            var screenshotPath = Path.Combine(projectRootDirectory, relativePath);

            // Screenshots klasörünün mevcut olduğundan emin olun
            
            Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));

            screenshot.SaveAsFile(screenshotPath);
            Console.WriteLine("Screenshot saved to: " + screenshotPath);
        }

        public static void QuitDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during driver quit: {ex.Message}");
                }
                finally
                {
                    driver.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Driver is null, nothing to quit.");
            }
        }
    }
}
