using System;
using System.Collections.Generic;
using System.Linq;
using Danfe.Core;

namespace Danfe.Nota
{
    public class DanfeBody
    {
        public dynamic Nfe { get; set; }
        public dynamic Det { get; set; }

        public DanfeBody(dynamic nfe, int page, int size)
        {
            Nfe = nfe;
            GetDetItens(page - 1);
        }

        private void GetDetItens(int page)
        {
            var list = Nfe.infNFe.det as List<DanfeDynamicXml>;
            var size = page * DanfePrintManager.MAX_ITEM_PER_PAGE;

            Det = list.Skip(size).Take(DanfePrintManager.MAX_ITEM_PER_PAGE);
        }
    }
}
