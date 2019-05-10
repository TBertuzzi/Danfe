using System;
using System.Collections.Generic;

namespace Danfe.Nota
{
    public class DanfePrintViewer
    {
        public List<DanfePage> Pages { get; set; }

        public DanfePrintViewer(string path)
        {
            var manager = new DanfePrintManager(path);

            Pages = manager.GeneratePages();
        }
    }
}
