using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCAResults
{
    // A class that represents a set of results for CAs for a student in a module
    public class ModuleCAResults
    {
        // Auto-implemented properties for module name, credits, and student name
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public string StudentName { get; set; }

        // A collection of results for CAs in the module
        private readonly List<int> caResults;

        // A constructor that takes the module name, credits, and student name as parameters
        public ModuleCAResults(string moduleName, int credits, string studentName)
        {
            ModuleName = moduleName;
            Credits = credits;
            StudentName = studentName;
            caResults = new List<int>(); // Initialize the collection as an empty list
        }

        // An indexer that allows retrieval and setting of a specific CA result
        public int this[int caNumber]
        {
            get
            {
                // Check if the CA number is valid (between 1 and the number of CAs)
                if (caNumber < 1 || caNumber > caResults.Count)
                {
                    // Throw an exception if not valid
                    throw new ArgumentException("Invalid CA number");
                }
                // Return the result at the corresponding index (subtract 1 because the list is zero-based)
                return caResults[caNumber - 1];
            }
            set
            {
                // Check if the CA number is valid (between 1 and the number of CAs + 1)
                if (caNumber < 1 || caNumber > caResults.Count + 1)
                {
                    // Throw an exception if not valid
                    throw new ArgumentException("Invalid CA number");
                }
                // Check if the value is valid (between 0 and 100)
                if (value < 0 || value > 100)
                {
                    // Throw an exception if not valid
                    throw new ArgumentException("Invalid CA result");
                }
                // If the CA number is equal to the number of CAs + 1, add the value to the end of the list
                if (caNumber == caResults.Count + 1)
                {
                    caResults.Add(value);
                }
                // Otherwise, update the value at the corresponding index (subtract 1 because the list is zero-based)
                else
                {
                    caResults[caNumber - 1] = value;
                }
            }
        }

        // Override ToString to return all module details and CA results
        public override string ToString()
        {
            // Use a StringBuilder to build the output string
            StringBuilder sb = new StringBuilder();
            // Append the module name, credits, and student name
            sb.AppendLine($"Module Name: {ModuleName}");
            sb.AppendLine($"Credits: {Credits}");
            sb.AppendLine($"Student Name: {StudentName}");
            // Append each CA result with its number
            for (int i = 0; i < caResults.Count; i++)
            {
                sb.AppendLine($"CA{i + 1}: {caResults[i]}");
            }
            // Return the output string
            return sb.ToString();
        }
    }

    // A class to test the ModuleCAResults class using a try/catch block
    public static class TestModuleCAResults
    {
        public static void Main(string[] args)
        {
            try
            {
                // Create a new instance of ModuleCAResults with some initial values
                ModuleCAResults mcr = new ModuleCAResults("Programming", 10, "Alice");
                // Set some CA results using the indexer
                mcr[1] = 80;
                mcr[2] = 90;
                mcr[3] = 85;
                mcr[1] = 20;
                mcr[2] = 40;
                mcr[3] = 60;
                mcr[1] = 25;
                mcr[3] = 65;
                mcr[4] = 99;
                // Print the module details and CA results using ToString
                Console.WriteLine(mcr);
                // Try to access an invalid CA result using the indexer (should throw an exception)
                Console.WriteLine(mcr[4]);
            }
            catch (Exception e)
            {
                // Catch any exception and print its message
                Console.WriteLine(e.Message);
            }
        }
    }
}



