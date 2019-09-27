using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Assincrono_Metodo_Click(object sender, RoutedEventArgs e)
        {
            Resultado.Text = "";
            var tempo = Stopwatch.StartNew();
            await ExecutarDownloadAsync();
            tempo.Stop();

            var tempogasto = tempo.ElapsedMilliseconds;


            Resultado.Text += $"Tempo gasto para essa ação assincrona foi de {tempogasto} milisegundos.";
        }

        private List<string> WebSites() =>
            new List<string>
            {
                "https://www.onlineapp.com.br",
                "https://www.onbusca.com",
                "https://www.google.com.br",
                "https://www.microsoft.com/pt-br"
            };

        private void ImprimirResultado(SiteModel site)
        {
            Resultado.Text += $"O site {site.Url},  possui {site.Conteudo.Length} caracteres.{Environment.NewLine} ";
        }

        private void ExecutarDownloadSync()
        {
            List<string> sites = WebSites();
            SiteModel website = new SiteModel();
            foreach (string site in sites)
            {
                website = BaixarSite(site);
                ImprimirResultado(website);
            }
        }


        private async Task ExecutarDownloadAsync()
        {
            List<string> sites = WebSites();
            SiteModel website = new SiteModel();
            foreach (string site in sites)
            {
                website = await Task.Run(() => BaixarSite(site));

                ImprimirResultado(website);
            }
        }
        private SiteModel BaixarSite(string url)
        {
            SiteModel site = new SiteModel
            {
                Url = url
            };

            using (WebClient cliente = new WebClient())
                site.Conteudo = cliente.DownloadString(url);

            return site;
        }


         Task<string> BaixarSite(string url)
        {

            return  "";

        }

        private void Sincrono_Metodo_Click(object sender, RoutedEventArgs e)
        {
            Resultado.Text = "";
            var tempo = Stopwatch.StartNew();
            ExecutarDownloadSync();
            tempo.Stop();

            var tempogasto = tempo.ElapsedMilliseconds;


            Resultado.Text += $"Tempo gasto para essa ação sincrona foi de {tempogasto} milisegundos.";
        }

        private async void Paralelo_Metodo_Click(object sender, RoutedEventArgs e)
        {
            Resultado.Text = "";
            var tempo = Stopwatch.StartNew();
            await ExecutarDownloadParalellAsync();
            tempo.Stop();

            var tempogasto = tempo.ElapsedMilliseconds;


            Resultado.Text += $"Tempo gasto para essa ação paralell foi de {tempogasto} milisegundos.";
        }

        private async Task ExecutarDownloadParalellAsync()
        {
            List<string> sites = WebSites();
            List<Task<SiteModel>> websites = new List<Task<SiteModel>>();

            foreach (string site in sites)
                websites.Add(Task.Run(() => BaixarSite(site)));

            var resultados = await Task.WhenAll(websites);

            foreach (var item in resultados)
                ImprimirResultado(item);



        }
    }
}
