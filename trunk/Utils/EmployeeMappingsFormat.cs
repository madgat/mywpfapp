using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using MyApp.Model;
using MyApp.ViewModel;

namespace MyApp.Utils
{
    public class EmployeeMappingsFormat : XmlFormatBase<ObservableCollection<EmployeViewModel>>
    {
        private const string EmployeeNamespace = "http://www.samsung.net/2013/employees";

        public EmployeeMappingsFormat()
            : base(EmployeeNamespace, "", "", new Version("1.0"))
        {
        }

        protected override XDocument WriteToXml(ObservableCollection<EmployeViewModel> data)
        {
            var document = new XDocument();
            var root = new XElement(DocumentNamespace + "mapping");

            WritEmployeeMappings(data, root);
            document.Add(root);

            return document;
        }

        private void WritEmployeeMappings(ObservableCollection<EmployeViewModel> data, XElement root)
        {
            
        }


        protected override ObservableCollection<EmployeViewModel> ReadFromXml(XDocument document)
        {
            return document == null ? null : ReadObjectMappingsConfiguration(document.Root);
        }

        private ObservableCollection<EmployeViewModel> ReadObjectMappingsConfiguration(XElement xElement)
        {
            var configuration = new ObservableCollection<EmployeViewModel>();

            Xml.AddToCollection(
                   ChildNodes(xElement, "Employee"),
                   ReadEmployee,
                   x =>
                   configuration.Add(x)
                   );
            return configuration;
        }

        private EmployeViewModel ReadEmployee(XElement xElement)
        {
            var employee = new EmployeViewModel();
            employee.Name = ToValue(ChildNode(xElement, "Name"));
            employee.Id = Convert.ToInt32(ToValue(ChildNode(xElement, "Id")));
            employee.Department = ToValue(ChildNode(xElement, "Department"));
            employee.ContactNumber = ToValue(ChildNode(xElement, "ContactNumber"));

            return employee;
        }


    }

}
