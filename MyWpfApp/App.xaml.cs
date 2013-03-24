using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace MyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += Application_UnhandledException;
        }

        private void Application_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (!Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Dispatcher.BeginInvoke(new Func<object>(()=>ReportErrorToDom(e)));
            }
        }

        private object ReportErrorToDom(DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var message = GetExceptionTrace(e.Exception);
                message = message.Replace("\r\n", "\n");
                ShowErrorMessage(message);
            }
            catch
            {
            }
            return null;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private static string GetExceptionTrace(Exception e)
        {
            if (e == null)
                return "";

            var inner = GetExceptionTrace(e.InnerException);

            return string.Format("{0}[HEAD]{1}\n \n{2}\n \n", inner, e.Message, e.StackTrace);
        }
    }
}
