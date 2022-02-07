using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JaywappWorld.Service.Helper
{
    public static class XmlHelper
    {
        public static bool TryGetAttributeValue(this XElement element, string name, out string value)
        {
            value = element.Attributes().FirstOrDefault(a => a.Name == name)?.Value;
            return !string.IsNullOrEmpty(value);
        }

        public static bool TryGetAttributeValue(this XElement element, string name, out DateTime date)
        {
            date = default;
            return element.TryGetAttributeValue(name, out string str)
                && DateTime.TryParse(str, out date);
        }
    }
}