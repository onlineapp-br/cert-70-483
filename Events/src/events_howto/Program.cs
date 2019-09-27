using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace events_howto
{
    class Program
    {
        static void Main(string[] args)
        {

            var id = 1;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.SendCompleted += SmtpClient_SendCompleted;
            smtpClient.SendAsync(null, id);




            var cagueta = new Cagueta("Militão");

            var eliade = new Desenvolvedor("Eliade", cagueta);
            var matheus = new Desenvolvedor("Matheus", cagueta);
            var marcus = new Desenvolvedor("Marcus", cagueta);

            Console.WriteLine("Curtindo youtube de boa...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine("Fala meu Deus");

            cagueta.LeviChegou(); //ok

            Console.ReadLine();
        }

        private static void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public class Cagueta
        {
            public string Nome { get; private set; }

            public event EventHandler<CaguetaAvisandoEventArgs> LeviEstaChegando;

            public void LeviChegou()
            {
                if (LeviEstaChegando != null)
                    LeviEstaChegando(this, new CaguetaAvisandoEventArgs("Direita"));
            }

            public Cagueta(string nome)
            {
                Nome = nome;
            }

            public override string ToString()
            {
                return Nome;
            }
        }

        public class Desenvolvedor
        {
            public Desenvolvedor(string nome, Cagueta cagueta)
            {
                Nome = nome;
                cagueta.LeviEstaChegando += TomarTapaNaCabeca;
            }
            public string Nome { get; }

            public void TomarTapaNaCabeca(object sender, CaguetaAvisandoEventArgs e)
            {
                Console.WriteLine("Cadê ele " + (sender as Cagueta) + " ???");
                Console.WriteLine("Na sua " + e.Posicao + " cara");
                Console.WriteLine("ALT + TAB rapidao");
                Console.WriteLine("Top " + (sender as Cagueta) + " valeu man");
            }
        }

        public class CaguetaAvisandoEventArgs : EventArgs
        {
            public CaguetaAvisandoEventArgs(string posicao)
            {
                Posicao = posicao;
            }

            public string Posicao { get; }
        }
    }
}
