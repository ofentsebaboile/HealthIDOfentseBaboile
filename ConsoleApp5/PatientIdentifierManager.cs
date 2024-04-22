using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp5
{
    public class PatientIdentifierManager
    {
        public PatientIdentifierManager() { }
        public static Dictionary<string, string> patientRecords = new Dictionary<string, string>();
        public static void AssignPatient(string identifier, string name)
        {
            if (!patientRecords.ContainsKey(identifier))
            {
                patientRecords.Add(identifier, name);
            }
        }

        public static string IssueIdentifier(string identifier, string gender)
        {
            // Extracting the first 3 characters
            string prefix = identifier.Substring(0, 3);

            // Extracting the next 4 characters
            string numbers = identifier.Substring(3, 4);

            // Extracting the gender code
            string FirstCharacter = identifier.Substring(7, 1);

            if(prefix == "ZZZ" & numbers == "9999" & FirstCharacter == "Z")
            {
                Console.WriteLine("Error");
                return "Error";
            }

            char nextCharacter = 'A';
            int nextNumber;
            string nextPrefix;

            // Handling increment of gender code
            if (FirstCharacter[0] == 'Z')
            {
                
                

                // Handling increment of numbers
                if (numbers == "9999")
                {
                    nextCharacter = IncrementFirstCharacter(FirstCharacter[0]);
                    // Handling increment of prefix
                    nextPrefix = IncrementPrefix(prefix);
                    nextNumber = Convert.ToInt32(numbers);  // Reset numbers to 1 after incrementing prefix
                }
                else
                {
                    nextNumber = int.Parse(numbers) + 1;
                    nextPrefix = prefix;
                }
            }
            else
            {
                nextCharacter = (char)(FirstCharacter[0] + 1);
                nextNumber = int.Parse(numbers);
                nextPrefix = prefix;
            }

            string newGender = gender == "Male" ? "01" : "02";
           

                Console.WriteLine($"{nextPrefix}{nextNumber:D4}{nextCharacter}-{newGender}");
            
            return $"{nextPrefix}{nextNumber:D4}{nextCharacter}-{newGender}";
        }

        public static string IncrementPrefix(string prefix)
        {
            char[] prefixChars = prefix.ToCharArray();
            // Increment the last character of the prefix
            prefixChars[prefixChars.Length - 1] = IncrementCharacter(prefixChars[prefixChars.Length - 1]);

            // If the last character reached 'Z', stop the incrementation
            if (prefixChars[prefixChars.Length - 1] == 'Z')
            {
                // Check if the second character needs to be incremented
                if (prefixChars[prefixChars.Length - 2] != 'Z')
                {
                    // Increment the second character
                    prefixChars[prefixChars.Length - 2] = IncrementCharacter(prefixChars[prefixChars.Length - 2]);
                }
                else
                {
                    // Check if the first character needs to be incremented
                    if (prefixChars[prefixChars.Length - 3] != 'Z')
                    {
                        // Increment the first character
                        prefixChars[prefixChars.Length - 3] = IncrementCharacter(prefixChars[prefixChars.Length - 3]);
                    }
                    else
                    {
                        // If all characters are 'Z', return "ZZZ"
                        return "ZZZ";
                    }
                }
            }

            // Return the incremented prefix
            return new string(prefixChars);
        }

        private static char IncrementCharacter(char c)
        {
            return c == 'Z' ? 'Z' : (char)(c + 1);
        }

        private static char IncrementFirstCharacter(char c)
        {
            return c == 'Z' ? 'A' : (char)(c + 1);
        }



        public static void GenerateReport()
        {
            var sortedRecords = patientRecords.OrderBy(x => x.Value);

            foreach (var record in sortedRecords)
            {
                string[] parts = record.Key.Split('-');
                string identifier = parts[0];
                string genderCode = parts[1]; // Extract the gender code from the identifier
                string gender = genderCode == "01" ? "Male" : "Female"; // Determine the gender based on the gender code
                Console.WriteLine($"{record.Value}: {record.Key}: {gender}");
            }
        }
    }
}
