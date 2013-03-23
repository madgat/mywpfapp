using System.Collections.ObjectModel;
using MyApp.Data;
using MyApp.Utils;
using MyApp.ViewModel;

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
    }
}
