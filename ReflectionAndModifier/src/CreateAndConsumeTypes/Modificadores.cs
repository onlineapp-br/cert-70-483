using System;

namespace CreateAndConsumeTypes
{

    #region Public
    //public: dá acesso a livre a classe
    public class Publico
    {
        public void MetodoPublico() => Console.WriteLine("Metodo Publico");
    }
    #endregion

    #region Protected
    //protected: Permite acesso das informações somente a classe base herdada
    public class Modificadores:Protegida
    {
        public Modificadores()
        {
            ValorProtegido = 10;
            MetodoProtegido();
        } 
    }
    public class Protegida
    {
        protected int ValorProtegido { get; set; }
        protected void MetodoProtegido()
        {
            Console.WriteLine($"Meu valor Protegido é de {ValorProtegido} ");
        }
    }
    #endregion

    #region Modificador Virtual
    //virtual: Permite override da classe herdada
    public class Virtual
    {
        public virtual void MetodoVirtual() => Console.WriteLine("Opa metodo virtual");
    }
   public class Reescrita: Virtual
    {
        public override void MetodoVirtual()
        {
            Console.WriteLine("Opa permite override");
            base.MetodoVirtual();
        }
    }
    public class Novo : Virtual
    {
        public new void MetodoVirtual() => Console.WriteLine("Opa metodo Virtual new");
    }
    #endregion

    #region Modificador Sealed
    //Metodo override informado como selead não permite override
    public class Selar
    {
        public virtual void MetodoSelado() => Console.WriteLine("Metodo a ser selado");
    }
    public class Selada : Selar
    {
        sealed public override void MetodoSelado() => Console.WriteLine("Opa metodo selado ");
    }

    // Não permite override uma vez setado como sealed
    public class Selado2:Selada
    {
        //protected override void MetodoSelado()
        //{
        //    base.MetodoSelado();
        //}
    }
    #endregion

    #region Modificador Internal
    //Não permite que seja acessado por outro Assembly
    internal class Interna
    {
        public void MetodoInterno() => Console.WriteLine("Opa metodo interno");
    }
    #endregion

    #region Readonly
    // somente é permitida a atribuição no construtor, em outros lugares somente permite a leitura dentro da classe(private)
    public class Leitura
    {
        private readonly string ler;
        public Leitura()
        {
            ler = "Eu li";
            Console.WriteLine(ler);

        }
    }
    #endregion
}
