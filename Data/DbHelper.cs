using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyApp.Data
{
    public class DbHelper
    {
        private string filepath = "EmployeeMaster.xml";
        public string GetData()
        {
            var fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\" + filepath, FileMode.OpenOrCreate, FileAccess.Read);
            var myReader = new StreamReader(fs);

            var xml = string.Empty;
            while (!myReader.EndOfStream)
            {
                xml += myReader.ReadLine();
            }
            fs.Close();
            return xml;
        }

        public void SaveData(string newXml)
        {
            var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + filepath);
            writer.WriteLine(newXml);

            writer.Close();
        }
    }
}
