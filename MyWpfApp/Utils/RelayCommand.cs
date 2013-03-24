using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MyApp.Utils
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> onAction;

        public RelayCommand(Action<T> onExecute)
        {
            onAction = onExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (onAction != null)
                onAction((T) parameter);
        }
    }
}
