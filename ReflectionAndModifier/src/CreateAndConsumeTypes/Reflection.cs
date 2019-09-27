using System;

namespace CreateAndConsumeTypes
{
    public class Reflection
    {
        public void Opcao01()
        {
            Type f = typeof(Funcionario);
            object instance = Activator.CreateInstance(f);
            foreach (var prop in f.GetProperties())
            {
                prop.SetValue(instance, "Eliade");
                Console.WriteLine(prop.Name + "-" + prop.GetValue(instance));
            }
        }

        public void Opcao02()
        {
            //Nome da classe com namespace
            Type f = Type.GetType("CreateAndConsumeTypes.Funcionario");

            object instance = Activator.CreateInstance(f);
            foreach (var prop in f.GetProperties())
            {
                prop.SetValue(instance, "Eliade");
                Console.WriteLine(prop.Name + "-" + prop.GetValue(instance));
            }
        }

        public void ChamarMetodoSemParametro()
        {
            var tipo = typeof(Funcionario);
            var instancia = Activator.CreateInstance(tipo);

            var nome = tipo.GetProperty("Nome");
            nome.SetValue(instancia, "Júnior");

            var salario = tipo.GetProperty("Salario");
            salario.SetValue(instancia, 1000m);

            var metodo = tipo.GetMethod("Inicial");
            metodo.Invoke(instancia, null);

        }

        public void ChamarMetodoComParametro()
        {
            var tipo = typeof(Funcionario);
            var instancia = Activator.CreateInstance(tipo);

            var nome = tipo.GetProperty("Nome");
            nome.SetValue(instancia, "Júnior");

            var salario = tipo.GetProperty("Salario");
            salario.SetValue(instancia, 1000m);

            var metodo = tipo.GetMethod("Aumento");
            metodo.Invoke(instancia, new object[] {500m });
        }
    }

    public class Funcionario
    {
        public string Nome { get; set; }
        public decimal Salario { get;  set; }
        public void Inicial() => Console.WriteLine(Salario);
        public void Aumento(decimal aumento) => Console.WriteLine(Salario + aumento);

    }
}
