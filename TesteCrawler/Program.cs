using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesteCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCrawler();
            ExpressaoRegular();
            Console.ReadLine();
        }

        private static void ExpressaoRegular()
        {
            StreamReader x;
            string texto = "";
            string caminho = "C:\\Users\\chris\\source\\repos\\TesteResource\\TesteCrawler\\bin\\Debug\\texto.txt";
            x = File.OpenText(caminho);

            while (x.EndOfStream != true)
            {
                string linha = x.ReadLine();
                texto = texto + linha + " ";
            }

            var rgx = new Regex(@"(\d) RESOURCE IT SOLUTIONS [^\}]+?(\d) RESOURCE IT SOLUTIONS");
            var encontrados = rgx.Matches(texto);

            x.Close();
            SalvarArquivoTexto(encontrados);
        }

        private static async Task StartCrawler()
        {
            var url = "https://www.valor.com.br/valor-data";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(n => n.GetAttributeValue("class", "")
                    .Equals("item")).ToList();

            var cotacaoDolar = divs[0].Descendants("span").FirstOrDefault().InnerText;

            SalvarArquivoTexto(cotacaoDolar);
        }

        private static void SalvarArquivoTexto(string cotacaoDolar)
        {
            StreamWriter x;
            string caminho = "C:\\Users\\chris\\source\\repos\\TesteResource\\TesteCrawler\\bin\\Debug\\arqCotDollar.txt";

            x = File.CreateText(caminho);

            x.WriteLine(cotacaoDolar);
            x.Close();
        }

        private static void SalvarArquivoTexto(MatchCollection encontrados)
        {
            StreamWriter x;
            string caminho = "C:\\Users\\chris\\source\\repos\\TesteResource\\TesteCrawler\\bin\\Debug\\textoRegex.txt";

            x = File.CreateText(caminho);

            foreach (Match item in encontrados)
            {
                x.WriteLine(item.Value);
            }

            x.Close();
        }


    }
}
