using System.Collections.ObjectModel;
using MyApp.Data;
using MyApp.Utils;
using MyApp.ViewModel;
using System.Linq;


namespace MyApp.BLL
{
    public class Employee
    {
        public ObservableCollection<EmployeViewModel> GetData()
        {
            var dbHelper = new DbHelper();
            var xml = dbHelper.GetData();

            var formatter = new EmployeeMappingsFormat();

            var data = formatter.Read(xml);

            return data;
        }

        public EmployeViewModel Find(int id)
        {
            var employeeData = GetData();
            var data = employeeData.FirstOrDefault(x => x.Id == id);

            return data;
        }


        public bool Save(EmployeViewModel viewModel)
        {
            var collection = GetData();

            collection.Add(viewModel);
            var formatter = new EmployeeMappingsFormat();
            formatter.Write(collection);

            return true;
        }
    }
}
