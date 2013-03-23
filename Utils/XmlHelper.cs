using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.XPath;
using System.Xml;

namespace MyApp.Utils
{
    /// <summary>
    /// The xml.
    /// </summary>
    public static class Xml
    {
      
        public static XNamespace Namespace(string namespaceName)
        {
            return XNamespace.Get(namespaceName);
        }

       
        public static XDocument ParseDocument(string xml)
        {
            return XDocument.Parse(xml);
        }

      
        public static XElement AddChildNode(XName name, XElement parent)
        {
            var element = new XElement(name);

            if (parent != null)
                parent.Add(element);

            return element;
        }

        public static void AddNamespace(XElement parent, string prefix, string ns)
        {
            var a = new XAttribute(XNamespace.Xmlns + prefix, ns);
            parent.Add(a);
        }

        
        public static XElement AddChildNodes<T>(XElement parent, XName name, Action<T, XElement> action,
                                                IEnumerable<T> collection)
        {
            if (collection != null)
                foreach (T item in collection)
                {
                    XElement element = AddChildNode(name, parent);
                    if (action != null) action(item, element);
                }

            return parent;
        }

       
        public static void Add(XElement child, XElement parent)
        {
            parent.Add(child);
        }

       
        public static XElement Parse(string xml)
        {
            return XElement.Parse(xml);
        }

       
        public static XName Name(XNamespace ns, string name)
        {
            return ns.GetName(name);
        }

       
        public static string GetAttribute(XElement element, XName name)
        {
            XAttribute attribute = element.Attribute(name);
            return attribute == null ? null : attribute.Value;
        }

      
        public static void SetAttribute(XElement element, XName name, object value)
        {
            element.SetAttributeValue(name, value);
        }

     
        public static string ToValue(XElement element)
        {
            if (element == null)
                return null;

            return element.Value;
        }

       
        public static void SetValue(XElement element, string value)
        {
            element.Value = value;
        }

      
        public static IEnumerable<XElement> ChildNodes(XElement element, XName name)
        {
            return element == null ? new List<XElement>() : element.Elements(name);
        }

      
        public static IEnumerable<XElement> AllChildNodes(XElement element)
        {
            return element == null ? new List<XElement>() : element.Elements();
        }

      
        public static XElement SingleChild(XElement element)
        {
            return element != null ? element.Elements().Take(1).SingleOrDefault() : null;
        }

     
        public static string ElementNamespace(XElement element)
        {
            return element.Name.NamespaceName;
        }

       
        public static XElement ChildNode(XElement element, XName name)
        {
            return element == null ? null : element.Element(name);
        }

       
        public static void AddToCollection<T, R>(IEnumerable<T> source, Func<T, R> mapFunction, Action<R> addFunction)
        {
            if (source == null) return;

            foreach (R r in source.Select(mapFunction))
            {
                addFunction(r);
            }
        }

      
        public static ObservableCollection<R> ToCollection<T, R>(IEnumerable<T> source, Func<T, R> mapFunction)
        {
            var result = new ObservableCollection<R>();
            AddToCollection(source, mapFunction, result.Add);
            return result;
        }

     
        public static void AddToObservableCollection<T, R>(IEnumerable<T> source, Func<T, R> mapFunction,
                                                           ObservableCollection<R> collection)
        {
            AddToCollection(source, mapFunction, collection.Add);
        }

     
        public static List<R> ToList<T, R>(IEnumerable<T> source, Func<T, R> mapFunction)
        {
            var collection = new List<R>();
            AddToCollection(source, mapFunction, collection.Add);
            return collection;
        }

       
        public static Dictionary<K, R> ToDictionary<T, K, R>(IEnumerable<T> source, Func<T, R> mapFunction,
                                                             Func<R, K> keyFunction)
        {
            var collection = new Dictionary<K, R>();
            AddToCollection(source, mapFunction, text => collection.Add(keyFunction(text), text));
            return collection;
        }

    
        public static int ToInt(string text, int defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : Convert.ToInt32(text);
        }

        public static long ToLong(string text, long defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : Convert.ToInt64(text);
        }


        public static XElement SelectElement(XElement element, string expression, IXmlNamespaceResolver namespaceManager)
        {
            return element.XPathSelectElement(expression, namespaceManager);
        }

        public static IEnumerable<XElement> SelectElements(XElement element, string expression, IXmlNamespaceResolver namespaceManager)
        {
            return element.XPathSelectElements(expression, namespaceManager);
        }

        public static IXmlNamespaceResolver GetNamespaceResolver(XElement element, params XNamespace[] namespaces)
        {
            NameTable nameTable = new NameTable();
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(nameTable);

            foreach (var item in namespaces)
            {
                var prefix = element.GetPrefixOfNamespace(item);

                if (prefix != null)
                    namespaceManager.AddNamespace(prefix, item.NamespaceName);
                else
                    namespaceManager.AddNamespace(string.Empty, item.NamespaceName);
            }

            return namespaceManager;
        }
        
        public static bool ToBoolean(string text, bool defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : Convert.ToBoolean(text);
        }

   
        public static DateTime ToDate(string text, DateTime defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : DateTime.Parse(text);
        }
        
        public static string ToString(string text, string defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : text;
        }

    
        public static T ToEnum<T>(string text, T defaultValue)
        {
            if (String.IsNullOrEmpty(text))
                return defaultValue;

            return (T)Enum.Parse(typeof(T), text, true);
        }

    
        public static double ToDouble(string text, double defaultValue)
        {
            if (String.IsNullOrEmpty(text))
                return defaultValue;

            return text.ToLower() == "auto" ? defaultValue : (text.Equals("NaN") ? double.NaN : Convert.ToDouble(text));
        }
        
        public static double ToDoubleOrNan(string text)
        {
            return ToDouble(text, Double.NaN);
        }

        public static string GetAttribute(XElement element, string name, string defaultValue)
        {
            var value = GetAttribute(element, name);
            return value ?? defaultValue;
        }

       
    }
    
}