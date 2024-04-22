using ConsoleApp5;
using System.Collections.Generic;
using System.Linq;
using System;

class Program
{
    static List<string> commands = new List<string>();

    static void Main(string[] args)
    {
        // Subscribe to the ProcessExit event
        //AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

        // Read input lines until the end of input is reached
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            commands.Add(input);
        }
        foreach (string command in commands)
        {
            ProcessCommand(command);
        }

        Console.WriteLine("Type 'Exit' to exit the program.");
        while (true)
        {
            string inputCommand = Console.ReadLine();
            if (inputCommand.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            commands.Add(inputCommand);
        }

        // Generate the report and exit
        OnProcessExit(null, EventArgs.Empty);
        Console.WriteLine("on exit.");
    }

    static void OnProcessExit(object sender, EventArgs e)
    {
        // Process each command
        

        // Generate the report
        PatientIdentifierManager.GenerateReport();
    }

    static void ProcessCommand(string command)
    {
        string[] parts = command.Split(' ');
        string action = parts[0];

        switch (action)
        {
            case "Assign":
                string identifier = parts[1];
                string name = string.Join(" ", parts.Skip(2));
                PatientIdentifierManager.AssignPatient(identifier, name);
                break;
            case "Issue":
                string patientIdentifier = parts[1];
                string gender = parts[2];
                PatientIdentifierManager.IssueIdentifier(patientIdentifier, gender);
                break;
            default:
                Console.WriteLine($"Unknown action: {action}");
                break;
        }
    }
}
