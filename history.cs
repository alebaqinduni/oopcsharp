using System;
using System.IO;

namespace ClassStore
{
    internal class History
    {
        private string file = "history.txt";
        public void DisplayHistory()
        {
            ConsoleUI.Header("Store History");
            if (!File.Exists(file))
            {
                Console.WriteLine("No history found.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            ConsoleUI.Pause();
        }
    }
}
