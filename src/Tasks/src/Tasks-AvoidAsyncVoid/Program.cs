using System;
using System.Threading.Tasks;

namespace Tasks
{

    /* 
     * Evite utilizar async void ? 
     * Porque ? 
     * 
     * 
     * Resposta: Porque o método async void não consegue interceptar as exceções, o que causa o possivel problema de travamento da aplicação.
     *
     * Como resolver essa situação ?

     **/
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                AvoidAsyncvoid();
               
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Console.Read();
            
        }

        private static async void AvoidAsyncvoid()
        {
           
            Console.WriteLine("Metodo async void");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("Problema de uma Exception");
            throw new InvalidOperationException("Erro");
        }

        private static async Task UseAlwaysAsyncTask()
        {

            Console.WriteLine("Metodo async void");
            await Task.Delay(TimeSpan.FromSeconds(2));
            Console.WriteLine("Problema de uma Exception");
            throw new InvalidOperationException("Erro");
        }

    }
}
