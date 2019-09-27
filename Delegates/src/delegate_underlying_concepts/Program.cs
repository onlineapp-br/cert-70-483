using System.Collections.Generic;
using delegate_underlying_concepts.v1;

namespace delegate_underlying_concepts
{
    class Program
    {

        static void Main(string[] args)
        {
            var document = new Document(new SortedDictionary<int, string>(){
                { 1, "Hello World.\n" },
                { 2, "This is an important document.\n" },
                { 3, "Lots of confidential information here. \n " },
                { 4, "I hope you can keep it as a secret. " },
            }, DocumentType.Confidential);

            var orchestratorv1 = new PrinterOrchestratorv1();
            orchestratorv1.Print(document);
        }
    }
}
