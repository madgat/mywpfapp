using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyApp.Logging
{
    public class ErrorLog
    {
        public void SaveLog(string message)
        {
            var filepath = AppDomain.CurrentDomain.BaseDirectory +  "log\\exception.txt";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "log"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "log");
            StreamWriter writer = null;

            if (File.Exists(filepath))
            {
              writer =  File.AppendText(filepath);

            }
            else
            {
                writer = File.CreateText(filepath);
                
            }


            //var writer = new StreamWriter(filepath);
            writer.WriteLine("Error at:" + DateTime.Now);
            writer.WriteLine(message);

            writer.Close();
        }
    }
}
