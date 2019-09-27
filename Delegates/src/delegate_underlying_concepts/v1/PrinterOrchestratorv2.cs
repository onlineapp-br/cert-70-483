namespace delegate_underlying_concepts.v1
{
    public class PrinterOrchestratorv2
    {
        private Printer printer = new Printer();

        private delegate void PrintStep(Document document);

        public void Print(Document document)
        {
            PrintStep steps = new PrintStep(printer.AddHeader);

            steps += printer.AddWaterMark;

            if (document.DocumentType == DocumentType.Confidential)
                steps += printer.AddWaterMark;

            steps += printer.RemoveAllNonPrintableChars;
            steps += printer.ConvertToUTF8Chars;
            steps += printer.AddBlankPage;
            steps += printer.AddFooter;
            steps += printer.Printing;

            steps(document);
        }
    }
}