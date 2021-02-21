using OpenQA.Selenium;
using System;

namespace ConsoleApp22
{
    public class ChromeDriverTestTask
    {
        private readonly IRepository _repository;
        private readonly IWebDriver _webDriver;

        public ChromeDriverTestTask()
        {
            // Not using
            //_repository = new Repository();
            _webDriver = WebDriverFactory.GetWebDriver(true);
        }

        public void Execute()
        {
            try
            {
                Console.WriteLine("Task of searching top results for google was started.");
                var mysearch = Environment.GetEnvironmentVariable("MYSEARCH");

                if (string.IsNullOrEmpty(mysearch))
                {
                    Console.WriteLine("No search value was found on environment variable, returning");
                    return;
                }

                Console.WriteLine($"Searching for: {mysearch} on https://www.google.com.br");
                _webDriver.Navigate().GoToUrl("https://www.google.com.br");
                _webDriver.FindElement(By.Name("q")).SendKeys(mysearch);
                _webDriver.FindElement(By.TagName("form")).Submit();

                var resultados = _webDriver.FindElements(By.ClassName("yuRUbf"));
                Console.WriteLine($"Found {resultados.Count} registries.");

                foreach (var resultado in resultados)
                {
                    var texto = resultado.FindElements(By.TagName("a"))[0].GetAttribute("href");
                    Console.WriteLine($"Writing {texto} to repository ...");
                    //_repository.EscreverTeste(texto);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine("There was an exception: ");
                Console.WriteLine(e);
            }

        }
    }
}