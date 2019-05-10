using System;
using System.Collections.Generic;
using System.Linq;
using Danfe.Core;

namespace Danfe.Nota
{
    public class DanfePrintManager
    {
        public static int MAX_ITEM_PER_PAGE = 20;
        public static int MIN_ITEM_PER_PAGE = 15;

        private dynamic Nfe;
        private dynamic ProtNFe;

        public DanfePrintManager(string path)
        {
            Nfe = DanfeSerializer.DeserializerNFe(path);
            ProtNFe = DanfeSerializer.DeserializerProtNFe(path);
        }

        public List<DanfePage> GeneratePages()
        {
            return ApportionPages().ToList();
        }

        private IEnumerable<DanfePage> ApportionPages()
        {
            var pageSize = PageSize();
            for (int i = 1; i <= PageSize(); i++)
                yield return new DanfePage(Nfe, ProtNFe, i, pageSize);
        }

        private int PageSize()
        {
            var totalItems = (double)Nfe.infNFe.det.Count;

            if (totalItems <= MIN_ITEM_PER_PAGE)
                return 1;
            else if (totalItems <= MAX_ITEM_PER_PAGE)
                return 2;
            else
            {
                var pages = Convert.ToInt32(Math.Ceiling(totalItems / MAX_ITEM_PER_PAGE));
                return pages < 1 ? 1 : pages;
            }
        }
    }
}
