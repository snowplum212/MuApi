using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MuApi
{
    public class Util
    {
        private const string LogFilePath = @"C:\developer\DevLog.txt";

        public static void Log(string message)
        {
            string programName = Assembly.GetExecutingAssembly().GetName().Name;
            string timestamp = System.DateTime.Now.ToString("MM/dd HH:mm:ss");
            string logEntry = $"{programName} {timestamp} : {message}";

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(logEntry);
            }
        }
    }
}
