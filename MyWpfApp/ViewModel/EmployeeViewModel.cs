using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MyApp.Utils;

namespace MyApp.ViewModel
{
    public class EmployeViewModel : ViewModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }

        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }

        }

        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }

        }

        private string contactNumber;

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                OnPropertyChanged("ContactNumber");
            }

        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RefreshCommand { get; set; }


        public EmployeViewModel()
        {
            AddCommand = new RelayCommand<object>(OnSave);
            DeleteCommand = new RelayCommand<object>(OnDelete);
            EditCommand = new RelayCommand<object>(OnSave);
            RefreshCommand = new RelayCommand<object>(OnRefresh);


        }

        public void OnSave(object parameter)
        {
            var bllEmployee = new BLL.Employee();
            if(parameter !=null)
            {
                var dataToEdit = parameter as EmployeViewModel;
                var employee = bllEmployee.Find(dataToEdit.Id);

            }
            throw new Exception("Test");
        }

        public void OnDelete(object parameter)
        {

        }

        public void OnRefresh(object parameter)
        {
            
        }
    }


}
