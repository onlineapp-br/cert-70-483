using System.Collections.Generic;

namespace delegate_underlying_concepts
{
    public class Document
    {
        public Document(SortedDictionary<int, string> pages, DocumentType documentType)
        {
            this.Pages = pages;
            this.DocumentType = documentType;
        }

        public SortedDictionary<int, string> Pages { get; }
        public int TotalPages => Pages.Count;
        public DocumentType DocumentType;
    }
}