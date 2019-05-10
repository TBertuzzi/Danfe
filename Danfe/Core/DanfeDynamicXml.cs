using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;
using Danfe.Extensions;

namespace Danfe.Core
{
    public class DanfeDynamicXml : DynamicObject
    {
        private XElement XElement;
        private Dictionary<string, object> XDictionary;

        public string Value
        {
            get
            {
                return XElement.IsNull() ? string.Empty : XElement.Value;
            }
        }
        public string this[string attr]
        {
            get
            {
                return XElement.IsNull() ? string.Empty : XElement.Attribute(attr).Value;
            }
        }


        public DanfeDynamicXml()
        {
            XElement = null;
            XDictionary = XDictionary ?? new Dictionary<string, object>();
        }

        public DanfeDynamicXml(string filename)
        {
            XElement = XElement.Load(filename);
            XDictionary = XDictionary ?? new Dictionary<string, object>();
        }

        public DanfeDynamicXml(XElement Element)
        {
            XElement = Element;
            XDictionary = XDictionary ?? new Dictionary<string, object>();
        }


        public double ToDouble()
        {
            return XElement.ToDouble();
        }

        public DateTime? ToDateTime()
        {
            return XElement.ToDateTime();
        }

        public DanfeDynamicXml First()
        {
            if (XElement != null)
            {
                var node = XElement.Elements().First();

                if (node == null) return null;
                else return new DanfeDynamicXml(node);
            }
            else
                return null;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (XDictionary.Keys.Contains(binder.Name))
            {
                result = XDictionary[binder.Name];
            }
            else
            {
                var nodes = GetElements(binder.Name);
                result = PrepareGetMembeResult(binder, nodes);
                XDictionary.Add(binder.Name, result);
            }
            return true;
        }

        private object PrepareGetMembeResult(GetMemberBinder binder, IEnumerable<XElement> nodes)
        {
            var collections = new string[] { "det", "dup" };
            object result;

            if (nodes.IsEmpty())
            {
                if (collections.Contains(binder.Name))
                    result = new List<DanfeDynamicXml>();
                else
                    result = new DanfeDynamicXml();
            }
            else if (collections.Contains(binder.Name))
                result = nodes.Select(n => new DanfeDynamicXml(n)).ToList();
            else
                result = new DanfeDynamicXml(nodes.First());

            return result;
        }

        private IEnumerable<XElement> GetElements(string name)
        {
            if (XElement.IsNull()) return null;

            XNamespace xnameSpace = "http://www.portalfiscal.inf.br/nfe";
            return XElement.Elements(xnameSpace + name);
        }
    }
}
