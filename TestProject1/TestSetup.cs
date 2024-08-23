using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

public static class TestSetup
{
    public static IWebDriver InitializeDriver()
    {
        // Projenin kök dizinine git
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var projectRootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;

        // Göreli yolu oluştur
        var relativePath = Path.Combine("Driver", "chromedriver-mac-arm64", "chromedriver");
        var chromeDriverPath = Path.Combine(projectRootDirectory, relativePath);

        // Yolu kontrol edin
        Console.WriteLine("Computed Path: " + chromeDriverPath);
        Console.WriteLine("Directory Exists: " + Directory.Exists(Path.GetDirectoryName(chromeDriverPath)));
        Console.WriteLine("File Exists: " + File.Exists(chromeDriverPath));

        var options = new ChromeOptions();
        var driver = new ChromeDriver(chromeDriverPath, options);

        return driver;
    }
}
