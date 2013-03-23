using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MyApp.Utils.Interfaces;

namespace MyApp.Utils
{
    /// <summary>
    /// The base class for all xml formattable object
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    public abstract class XmlFormatBase<T> : ITextFormat<T> where T : new()
    {
        protected XNamespace DocumentNamespace { get; private set; }
        protected readonly XNamespace iNamespace = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

        public XmlFormatBase(string xmlns = "", string name = "", string description = "", Version version = null)
        {
            Name = name;
            Description = description;

            if (version != null)
                Version = version;
            else
                Version = new Version("0.0.0.0");

            this.DocumentNamespace = XNamespace.Get(xmlns);
        }

        #region IFormat<string,T> Members

      
        public string Name
        {
            get;
            private set;
        }

       
        public string Description
        {
            get;
            private set;
        }

       
        public Version Version
        {
            get;
            private set;
        }

      
        public T Read(string xml)
        {
            var document = XDocument.Parse(xml);

            var result = ReadFromXml(document);

            return result;
        }
        
        public string Write(T data)
        {
            var document = WriteToXml(data);

            if (document != null)
                return document.ToString(SaveOptions.None);

            return string.Empty;
        }

       
        protected abstract XDocument WriteToXml(T data);

       
        protected abstract T ReadFromXml(XDocument document);

        #endregion


       
        protected IEnumerable<XElement> ChildNodes(XElement parent, string name)
        {
            return Xml.ChildNodes(parent, DocumentNamespace.GetName(name));
        }

     
        protected XElement ChildNode(XElement parent, string name)
        {
            return Xml.ChildNode(parent, DocumentNamespace.GetName(name));
        }

      
        protected string GetAttribute(XElement element, string name)
        {
            return Xml.GetAttribute(element, name);
        }

     
        protected XElement AddNode(string name, XElement parent)
        {
            XElement element = Xml.AddChildNode(DocumentNamespace.GetName(name), parent);
            return element;
        }

       
        protected void AddNodes<T>(XElement parent, string name, Action<T, XElement> map, IEnumerable<T> items)
        {
            Xml.AddChildNodes(parent, DocumentNamespace.GetName(name), map, items);
        }

      
        protected void SetAttribute(XElement element, string name, object value)
        {
            Xml.SetAttribute(element, name, value);
        }

        protected string ToValue(XElement element)
        {
           return Xml.ToValue(element);
        }
    }
}
