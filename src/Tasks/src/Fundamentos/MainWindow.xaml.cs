using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fundamentos
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
       
        private async void Rodar_Click(object sender, RoutedEventArgs e)
        {

            var t1 = Task.Factory.StartNew(() =>
            {
                Debug.Text = "Opa você não pode fazer isto";
            });








            //t1.ContinueWith(t =>
            //{
            //    if (t.IsFaulted) { }
            //});


            //await Task.Delay(1000);

            //Task.Delay(500).ContinueWith(_ =>
            //{
            //    Dispatcher.Invoke(() =>
            //    {

            //        Debug.Text = "Done";
            //    });
            //});
        }
    }
}
