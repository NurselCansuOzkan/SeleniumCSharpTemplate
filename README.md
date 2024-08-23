# VSSeleniumTestProjects
Selenium C#, NUnit Framework and Specflow Testing

### Platform ve Sürümler
Macbook M1 cihazda, Visual Studio Code ile C# Dev Kit kullanılarak geliştirme yapılmıştır.
- ChromeDriver için mac-arm64 platform uyumlu https://storage.googleapis.com/chrome-for-testing-public/127.0.6533.72/mac-arm64/chromedriver-mac-arm64.zip bu linkten indirilmiştir.
- Windows cihazda test edilebilmesi için uygun driver indirilip TestSetup.cs dosyasında yolu eklenmelidir.

![results](/TestProject1/Reports/test.png)

### LivingDoc Kullanımı
- export PATH="$PATH:/Users/nurselcansu/.dotnet/tools"

- livingdoc --version 

- livingdoc test-assembly TestProject1/bin/Debug/net8.0/TestProject1.dll --output TestProject1/Reports --output-type HTML --test-execution-json TestProject1/bin/Debug/net8.0/TestExecution.json
