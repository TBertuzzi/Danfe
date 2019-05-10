using System;
namespace Danfe.Nota
{
    public class DanfeHeader
    {
        public dynamic Ide { get; set; }
        public dynamic Emit { get; set; }
        public dynamic Dest { get; set; }
        public dynamic Total { get; set; }
        public dynamic Transp { get; set; }
        public dynamic Cobr { get; set; }

        public DanfeHeader(dynamic nfe)
        {
            Ide = nfe.infNFe.ide;
            Emit = nfe.infNFe.emit;
            Dest = nfe.infNFe.dest;
            Total = nfe.infNFe.total;
            Transp = nfe.infNFe.transp;
            Cobr = nfe.infNFe.cobr;
        }
    }
}
