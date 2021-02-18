using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace ConsoleApp22
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(bool headless)
        {
            var chromeDriverDirectory = Environment.CurrentDirectory;
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", chromeDriverDirectory);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("plugins.plugins_disabled", "Chrome PDF Viewer");
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddArgument("--no-sandbox");
            options.AddArgument("--start-maximized");

            if (Environment.OSVersion.Platform == PlatformID.Unix)
                options.BinaryLocation = "/opt/google/chrome/chrome";

            options.AddExcludedArguments(new List<string> { "enable-automation" });

            if (headless)
                options.AddArguments("--headless");

            var chromeDriver = new ChromeDriver(chromeDriverDirectory, options);

            return chromeDriver;
        }
    }
}
