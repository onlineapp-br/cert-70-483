using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace GCPerformance.Console
{
    public class Program
    {

        const string arquivocsv = @"C:\Users\claudemir.junior\source\repos\GCPerformance\GCPerformance.Console\ArquivosMedias.csv";

        static void Main()
        {
            var sw = Stopwatch.StartNew();
            var linhas = File.ReadAllLines(arquivocsv);

            var soma = 0d;
            var total = 0;
            string linha;

            using (var fs = File.OpenRead(arquivocsv))
            using (var reader = new StreamReader(fs))
                while ((linha = reader.ReadLine()) != null)
                {
                    var itens = linha.Split(',');

                    if (itens[1] == "110")
                    {
                        soma += double.Parse(itens[2], CultureInfo.InvariantCulture);
                        total++;
                    }
                }

            global::System.Console.WriteLine($"Média é : {soma / total} em {total} votos.");

            sw.Stop();
            global::System.Console.WriteLine($"Total de {sw.ElapsedMilliseconds} ms.");
            global::System.Console.ReadKey();
        }
    }
}
