using System;

namespace CreateAndConsumeTypes
{

    class Program
    {
        static void Main(string[] args)
        {
            //ValueTypes - int, bool, decimal, enum, struct, float - tipos primitivos
            ///ReferenceType - class, string, coleções
            ///Dynamic - ExpandObject, dynamic, DynamicObject

            dynamic nome = "Junior";

            dynamic idade = 12;

            //dynamic classe = new Junior { Idade = 18 };

            //classe.Idade = 20;
            //Console.WriteLine(classe.Idade);
            //Console.Read();

            //Reflection C#
            // 
            var ops = new Reflection();
            ops.ChamarMetodoComParametro();
            //opcao 1
            //var aluno = new Aluno() { AnoLetivo = 2019, Matricula = 323213 };
            //var tipo = typeof(Aluno);
            //var prop = tipo.GetProperties();
            //var instancia = Activator.CreateInstance(tipo);
            //var mat = tipo.GetProperty("Matricula");
            //var anoletivo = tipo.GetProperty("AnoLetivo");
            //var metodo = tipo.GetMethod("NotaA");

            //metodo.Invoke(instancia,new object[] { 11 });

            //mat.SetValue(instancia, 1020);
            //anoletivo.SetValue(instancia, 2020);

            //foreach (var item in prop)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.GetValue(instancia));
            //}

            // Console.WriteLine(prop.Name);
            Console.Read();


           



        }
        public class Aluno
        {
            public int Matricula { get; set; }
            public int AnoLetivo { get; set; }

            public void Nota() => Console.WriteLine("Opa nota 10");
            public void NotaA(int nota) => Console.WriteLine("Opa nota"+ nota);
        }

        public class Protegido1
        {
             void Proteger()
            {

            }
        }


        public class Protegido2: Protegido1
        {
            public Protegido2()
            {
                
            } 

            
        }

        //public class NovoAluno : Aluno
        //{
        //    public NovoAluno()
        //    {

        //    }

        //    public override sealed void Nota()
        //    {
        //        base.Nota();
        //    }
        //}

                internal class Notafiscal
        {
            public int Numero { get; set; }
        }



        public class Proteger
        {
            protected int Anos { get; set; }

            public void AtribuiAno(int anos)
            {
                Anos = anos;
            }
        }
        public class Junior : Proteger
        {
            //private Permite somente dentro da classe
            private int Idade { get; set; }

            //readonly Somente permite atribuiçao no Construtor
            private readonly string rg;
            public Junior()
            {
                Anos = 102;
                rg = "3213123";
                Idade = 18;
            }


            //public string MeuRg()
            //{
            //    return rg;
            //}
        }
        //static void Main(string[] args)
        //{
        //    var quatropatas = typeof(Cachorro).GetConstructor(new Type[0]);
        //    var resultado = (Cachorro)quatropatas.Invoke(null);

        //    Console.WriteLine(resultado.NumeroPatas);

        //    Console.Read();

        //    var duaspatas = typeof(Cachorro).GetConstructor(new[] { typeof(int) });
        //    var resultado2 = (Cachorro)duaspatas.Invoke(new object[] { 2 });

        //    Console.WriteLine(resultado2.NumeroPatas);

        //    Console.Read();

        //}
        //internal class Cachorro
        //{
        //    public Cachorro() => NumeroPatas = 4;
        //    public Cachorro(int patas) => NumeroPatas = patas;

        //    public int NumeroPatas { get; private set; }
        //}
    }
}

