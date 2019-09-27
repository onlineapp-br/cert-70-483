using System;
using System.Threading;

namespace delegate_underlying_concepts.v1
{
    public class Printer
    {
        public void AddHeader(Document document)
        {
            document.Pages.Add(document.TotalPages - document.TotalPages, "_header");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("Header was added.");
        }

        internal void AddWaterMark(Document document)
        {
            document.Pages.Add(document.TotalPages - document.TotalPages - 1, "CONFIDENTIAL!!!");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("Confidential watermark was added.");
        }

        public void RemoveAllNonPrintableChars(Document document)
        {
            foreach (var page in document.Pages)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Console.WriteLine($"Non printable chars were remove at page {page.Key}.");
            }

            Console.WriteLine("All the non printable were removed.");
        }

        public void ConvertToUTF8Chars(Document document)
        {
            foreach (var page in document.Pages)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Console.WriteLine($"The content at page {page.Key} was converted to utf8.");
            }

            Console.WriteLine("The content was converted to UTF8");
        }

        public void AddFooter(Document document)
        {
            document.Pages.Add(document.TotalPages + 1, "_footer");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("Footer was added.");
        }

        public void AddBlankPage(Document document)
        {
            document.Pages.Add(document.TotalPages + 1, string.Empty);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("The blank page was added.");
        }

        public void Printing(Document document)
        {
            Console.WriteLine("Printing...");

            foreach (var page in document.Pages)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Console.WriteLine(page.Value);
            }
        }
    }
}