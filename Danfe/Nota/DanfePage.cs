using System;
namespace Danfe.Nota
{
    public class DanfePage
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public DanfeHeader Header { get; set; }
        public DanfeBody Body { get; set; }
        public DanfeFooter Footer { get; set; }
        public bool IsFirstPage
        {
            get
            {
                return Page.Equals(1);
            }
        }
        public bool IsLastPage
        {
            get
            {
                return Page.Equals(Size);
            }
        }

        public DanfePage(dynamic nfe, dynamic protNFe, int page, int size)
        {
            Page = page;
            Size = size;

            this.Header = new DanfeHeader(nfe);
            this.Body = new DanfeBody(nfe, page, size);
            this.Footer = new DanfeFooter(nfe, protNFe);
        }
    }
}
