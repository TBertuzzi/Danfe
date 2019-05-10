using System;

namespace Danfe.Core

{
    public class DanfeSerializer
    {
        public static dynamic DeserializerNFe(string path)
        {
            dynamic result = new DanfeDynamicXml(path);
            return result.NFe;
        }

        public static dynamic DeserializerProtNFe(string path)
        {
            dynamic result = new DanfeDynamicXml(path);
            return result.protNFe;
        }
    }
}
