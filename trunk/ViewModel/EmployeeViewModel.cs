using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
    }


}
