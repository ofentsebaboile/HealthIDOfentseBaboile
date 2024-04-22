using ConsoleApp5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2
{
    [TestFixture]
    public class PatientIdentifierManagerTests
    {
        [Test]
        public void AssignPatient_Should_Add_Patient_Record()
        {
            // Arrange
            string identifier = "GUQ0034T-01";
            string name = "Mamat Buhbash";

            // Act
            PatientIdentifierManager.AssignPatient(identifier, name);

            // Assert
            Assert.IsTrue(PatientIdentifierManager.patientRecords.ContainsKey(identifier));
            Assert.AreEqual(name, PatientIdentifierManager.patientRecords[identifier]);
        }

        [TestCase("KLM0001A-01", "Male", "KLM0001B-01")]
        [TestCase("KLM9999Z-02", "Female", "KLN9999A-02")]
        [TestCase("ZZZ9999Z-02", "Male", "Error")]
        [TestCase("HJY9890T-02", "Male", "HJY9890U-01")]
        public void IssueIdentifier_Should_Return_Correct_Next_Identifier(string identifier, string gender, string expected)
        {
            // Act
            string result = PatientIdentifierManager.IssueIdentifier(identifier, gender);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GenerateReport_Should_Print_Correct_Records()
        {
            // Arrange
            PatientIdentifierManager.patientRecords.Clear();
            PatientIdentifierManager.patientRecords.Add("GUQ0034T-01", "Mamat Buhbash");
            PatientIdentifierManager.patientRecords.Add("HJY9890T-02", "Maphiri Khama");

            // Act
            PatientIdentifierManager.GenerateReport();

            // Assert
            // You can use console output assertions here to check if the report is generated correctly
            // You can redirect Console output to a StringWriter and assert against its contents
        }
    }
}
