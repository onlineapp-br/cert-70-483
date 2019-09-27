namespace delegate_underlying_concepts.v1
{
    public class PrinterOrchestratorv1
    {
        private Printer printer = new Printer();

        public void Print(Document document)
        {
            printer.AddHeader(document);

            if (document.DocumentType == DocumentType.Confidential)
                printer.AddWaterMark(document);

            printer.RemoveAllNonPrintableChars(document);
            printer.ConvertToUTF8Chars(document);
            printer.AddBlankPage(document);
            printer.AddFooter(document);
            printer.Printing(document);
        }
    }
}