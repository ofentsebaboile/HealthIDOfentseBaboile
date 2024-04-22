Overview:

The Patient Identifier Manager is a console application designed to manage patient identifiers in a healthcare system. It provides functionality to assign identifiers to new patients, issue new identifiers based on existing ones, and generate reports of patient records.

Design Decisions:

Patient Identifier Format: The patient identifier format consists of a prefix, numbers, and a gender code. The prefix and the numbers are incremental, and the gender code indicates the gender of the patient.

Incrementation Logic:

The logic for incrementing identifiers is implemented to handle various edge cases, such as reaching the maximum value for numbers or letters.

Data Structure: Patient records are stored in a dictionary, allowing for efficient retrieval and manipulation of patient data.

How to Run:

Requirements

Visual Studio Professional 2022  (or any compatible IDE)
.NET Core SDK

Instructions:

Download the provided zip file containing the Visual Studio project.
Extract the contents of the zip file to a directory of your choice.
Open the solution file (.sln) in Visual Studio.
Build the solution to ensure all dependencies are resolved.
Set the startup project to the console application project (ConsoleApp5).
Run the application by pressing F5 or clicking the "Start" button in Visual Studio.
Follow the instructions in the console to perform various operations such as assigning identifiers, issuing new identifiers, and generating reports.

NB===============================================================================

(You can paste commands in the console and press Enter twice to process the commands and get the results. for example paste 
"
Assign NHU0001A-01 John Doe
Issue KLM0001A-01 Male
Assign KLM9999Z-02 Jane Smith
Issue KLM9999Z-02 Female
Issue ZZZ9999Z-02 Male
Assign NHJ0002A-01 Alice Johnson
Issue HJY9890T-02 Male

"
and press Enter twice. All this commands will be processed at once. or you can paste one command like

"
Issue KLM0001A-01 Male

"

and press Enter twice and the command will be executed
)

To exit application and print Report, Type Exit and press Enter

==========================================================================================

Running Tests


Open the solution file (.sln) in Visual Studio.
Set the test project as the startup project.
Build the solution to ensure all dependencies are resolved.
Run the tests by  Rigt click Test2 Project > Run All Tests .
Dependencies
.NET Core SDK