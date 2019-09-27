using System;
using System.Threading.Tasks;
using System.Windows;

/* 
 * Programador Senior foi utilizar o método assincrono utilizando Task e a palavra reservada Wait e a aplicação travou...
 * 
 * Porque  ???
 * 
 * Para aplicações que possuem um contexto proprio, como uma aplicação Desktop ou Web, elas possuém uma Thead própria de UI nomeada como Thead UI ou Thead Request. 
 * E ao chamar o método Wait ou Result, a Thread fica bloqueada aguardando o método assincrono o famoso
 * DeadLock, travando a aplicação.
 * 
 * Resolução ?
 * Para Resolver este problema podemos informar para nosso método assincrono que não importa o contexto de retorno através do Método ConfigurationAwait(false)

 * */

namespace Tasks_AvoidResultAndWait
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

        private void Executar_Click(object sender, RoutedEventArgs e)
        {
            var delayTask = DelayAsync();
            delayTask.ConfigureAwait(false);
            Resultado.Text = "Uhuuuuu Wait ! Esse é o meu craque !!!";


        }
        private async Task DelayAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
        private async Task<string> ResultAsync(string nome)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return $"Uhuuuuu Result ! Esse é o  {nome}";
        }

        private  void Executar_Result_Click(object sender, RoutedEventArgs e)
        {
            var resultaAsync = ResultAsync("meu craque !");
            Resultado.Text = resultaAsync.Result;
        }
    }
}
