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
            _repository = new Repository();
            _webDriver = WebDriverFactory.GetWebDriver(true);
        }

        public void Execute()
        {
            var pesquisa = Environment.GetEnvironmentVariable("PESQUISA");

            if (string.IsNullOrEmpty(pesquisa))
            {
                pesquisa = "Valor Vazio";
            }

            Console.WriteLine($"Task iniciada. Valor a pesquisar: {pesquisa}");
            _webDriver.Navigate().GoToUrl("https://www.google.com.br");
            _webDriver.FindElement(By.Name("q")).SendKeys(pesquisa);
            _webDriver.FindElement(By.Name("f")).Submit();

            var resultados = _webDriver.FindElements(By.ClassName("yuRUbf"));

            foreach (var resultado in resultados)
            {
                var texto = resultado.FindElements(By.TagName("a"))[0].GetAttribute("href");
                _repository.EscreverTeste(texto);
            }

        }
    }
}