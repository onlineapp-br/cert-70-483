using System;
using System.Threading;

namespace Thead_Desafio_Novo
{

    // 🤓 Porque este código funciona em Debug, porém, em Release não ? Eis a questão !! 🤓
    class Program
    {
        static void Main()
        {
            var w = new Trabalhador();
            while (!w.EstáFinalizado) ;
            Console.WriteLine("O trabalhador está finalizado!");
            Console.ReadKey();

        }
    }

    class Trabalhador
    {
        public bool EstáFinalizado; // Acentuação roda no Visual Studio? 😲  

       
        public Trabalhador()
        {
            var thread = new Thread(Trabalhar);
            thread.Start();
        }

        private void Trabalhar()
        {
            Thread.Sleep(3000);
            EstáFinalizado = true;
        }
    }
}
