using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Danfe.Extensions
{
    internal static class XElementExtension
    {
        public static bool IsNull(this XElement element)
        {
            return element == null;
        }

        public static bool IsEmpty(this IEnumerable<XElement> elements)
        {
            return elements == null || elements.Count() == 0;
        }

        public static double ToDouble(this XElement element)
        {
            return element.IsNull() ? 0 : (double)element;
        }

        public static DateTime? ToDateTime(this XElement element)
        {
            return element.IsNull() ? null : (DateTime?)element;
        }
    }
}
