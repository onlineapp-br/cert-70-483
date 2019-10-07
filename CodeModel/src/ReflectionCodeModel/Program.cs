using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace ReflectionCodeModel
{
    class Program
    {
        static void ExibirTela(CodeCompileUnit compile)
        {
            using (VBCodeProvider csharp = new VBCodeProvider())
            {

                using (var memory = new MemoryStream())
                using (var output = new StreamWriter(memory))
                {
                    csharp.GenerateCodeFromCompileUnit(compile, output, new CodeGeneratorOptions());
                    output.Flush();

                    var bytes = memory.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(bytes));
                    Console.ReadLine();
                }
            }

        }
        public static bool CompilarCSharp(string sourceFile, string exeFile)
        {
            using (CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider())
            {
                CSharpCodeProvider provider = cSharpCodeProvider;

                // Parametros de configuração.
                CompilerParameters cp = new CompilerParameters();

                // Referencia de Assembly
                cp.ReferencedAssemblies.Add("System.dll");

                //Gera um executavel
                cp.GenerateExecutable = true;

                //Nome do Executavel
                cp.OutputAssembly = exeFile;

                cp.GenerateInMemory = false;

                //Chama o compilador
                CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);

                //Identitifica erros
                if (cr.Errors.Count > 0)
                {
                    Console.WriteLine("Errors building {0} into {1}",
          sourceFile, cr.PathToAssembly);
                    foreach (CompilerError ce in cr.Errors)
                    {
                        Console.WriteLine("  {0}", ce.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Source {0} built into {1} successfully.",
                        sourceFile, cr.PathToAssembly);
                }

                // Return the results of compilation.
                if (cr.Errors.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {

            CodeCompileUnit compile = new CodeCompileUnit();


            //Namespace
            var package = new CodeNamespace("Hello");
            package.Imports.Add(new CodeNamespaceImport("System"));



            //Class
            var minhaclasse = new CodeTypeDeclaration("Program")
            {
                IsClass = true,
                Attributes = MemberAttributes.Assembly
            };


            //Method

            var meumetodo = new CodeMemberMethod
            {
                Name = "Main",
                Attributes = MemberAttributes.Public | MemberAttributes.Static
            };


            //Propriedades 
            var minhapropriedade = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = "Valor",
                Type = new CodeTypeReference(typeof(decimal)),
                HasGet = true,
                HasSet = true
            };

            //Variaveis
            var minhavariavel = new CodeMemberField
            {
                Name = "strNome",
                Type = new CodeTypeReference(typeof(string))
            };



            //Parametros para Metodos
            var meuparametro = new CodeParameterDeclarationExpression(typeof(string[]), "args");
            meumetodo.Parameters.Add(meuparametro);

            //Conteúdo do método
            var meuconteudometodo = new CodeSnippetExpression("Console.WriteLine(\"Hello World\")");
            var meuconteudometodo2 = new CodeSnippetExpression("Console.ReadKey()");

            //Adiciona conteúdo do método
            meumetodo.Statements.Add(meuconteudometodo);
            meumetodo.Statements.Add(meuconteudometodo2);


            //Adiciona método
            minhaclasse.Members.Add(meumetodo);

            //Adiciona Classe ao namespace
            package.Types.Add(minhaclasse);

            //Adiciona Namespace com o compiler
            compile.Namespaces.Add(package);

            ExibirTela(compile);

        }
    }
}
