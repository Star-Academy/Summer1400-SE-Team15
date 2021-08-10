using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngineLibrary
{
    public class InputScanner : IInputScanner
    {
        private const string NoResult = "No Result";

        public string Scan()
        {
            return Console.ReadLine();
        }

        public void Print(HashSet<string> output)
        {
            if (!output.Any())
            {
                
                Console.WriteLine(NoResult);
                return;
            }
            foreach (var value in output)
            {
                Console.WriteLine(value);
            }
        }
    }
}