using System;
namespace Danfe.Nota
{
    public class DanfeFooter
    {
        public dynamic InfAdic { get; set; }
        public dynamic ProtNFe { get; set; }

        public DanfeFooter(dynamic nfe, dynamic protNFe)
        {
            this.InfAdic = nfe.infNFe.infAdic;
            this.ProtNFe = protNFe;
        }
    }
}
