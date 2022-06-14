using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH.DevTest.Junior.Data;
using CH.DevTest.Junior.DataObjects;
using IronXL;

namespace CH.DevTest.Junior
{
    /// <summary>
    /// Instructions:
    /// TODO:   1. Implement the patient object
    /// TODO:   2. Read the contents of the patients.csv file into a collection of patients
    /// TODO:   3. Write the following output to the screen (First name, Last name, Age, Date of Birth, Account Number)
    /// TODO:       #1 - display all patients 
    /// TODO:       #2 - display all patients with last name of 'smith'
    /// TODO:       #3 - display all patients missing a date of birth
    /// </summary>
    public class Program
    {
        private const string InputFilePath = @".\patients.csv";

        

        /*public static string [] readRecord(string pFilepath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(pFilepath);
            }
            catch (Exception ex)
            {

                Console.WriteLine('Error');
            }

        }*/

        static void Main(string[] args)
        {

            /// TODO:   1. Implement the patient object
            Console.WriteLine("TODO:   1. Implement the patient object");
            /// TODO:   2. Read the contents of the patients.csv file into a collection of patients
            Console.WriteLine("TODO: 2. Read the contents of the patients.csv file into a collection of patients");
            
            string[] results = File.ReadAllLines(InputFilePath);

            var myArray = results.Where((source, index) => index != 0).ToArray(); // removing header
       
            List<Patient> vListPatient = new List<Patient>();
            
            foreach ( var result in myArray)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    var vLine = result.Split(',');
                    //Console.WriteLine("FirstName: " + vLine[0] + " -> LastName: " + vLine[1] + " -> Age: " + vLine[2] + " -> DateOfBirth: " + vLine[3] + " -> AccountNumber: " + vLine[4]);

                    var vPatient = new Patient();
                    vPatient.FirstName = vLine[0];
                    vPatient.LastName = vLine[1];
                    vPatient.Age = Convert.ToInt32(vLine[2]);

                    if (!string.IsNullOrWhiteSpace(vLine[3]))
                    {
                        vPatient.DateOfBirth = Convert.ToDateTime(vLine[3]);
                    }
                    vPatient.AccountNumber = vLine[4];
                    

                    vListPatient.Add(vPatient);

                }
            }




            /// TODO:   3. Write the following output to the screen (First name, Last name, Age, Date of Birth, Account Number)

            Console.WriteLine("TODO:   3. Write the following output to the screen (First name, Last name, Age, Date of Birth, Account Number)");
            Console.WriteLine(results[0]);


            /// TODO:       #3.1 - display all patients
            Console.WriteLine("TODO: #3.1 - display all patients");
            foreach (var patient in vListPatient)
            {

                Console.WriteLine("FirstName: " + patient.FirstName +
                                  " -> LastName: " + patient.LastName +
                                  " -> Age: " + patient.Age +
                                  " -> DateOfBirth: " + patient.DateOfBirth +
                                  " -> AccountNumber: " + patient.AccountNumber);
               
            }

            /// TODO:       #3.2 - display all patients with last name of 'smith'

            Console.WriteLine("TODO: #2 - display all patients with last name of 'smith'");
            var vListPatientsWithSmith = vListPatient.Where(p => p.LastName == "Smith").ToList(); 

            foreach (var patient2 in vListPatientsWithSmith)
            {

                Console.WriteLine("FirstName: " + patient2.FirstName +
                                  " -> LastName: " + patient2.LastName +
                                  " -> Age: " + patient2.Age +
                                  " -> DateOfBirth: " + patient2.DateOfBirth +
                                  " -> AccountNumber: " + patient2.AccountNumber);

            }

            /// TODO:       #3.3 - display all patients missing a date of birth
            Console.WriteLine(" TODO: #3.3 - display all patients missing a date of birth");

            var vListPatientsMissingDateofBirth = vListPatient.Where(p => p.DateOfBirth.ToString() == "").ToList();

            foreach (var patient3 in vListPatientsMissingDateofBirth)
            {

                Console.WriteLine("FirstName: " + patient3.FirstName +
                                  " -> LastName: " + patient3.LastName +
                                  " -> Age: " + patient3.Age +
                                  " -> DateOfBirth: " + patient3.DateOfBirth +
                                  " -> AccountNumber: " + patient3.AccountNumber);

            }

            /// OPTIMIZE FORM WITH POO
            Console.WriteLine(" **********************************************************************************************");
            Console.WriteLine(" ********** OPTIMIZE FORM WITH object-oriented programming OOP ***************");

            /// TODO:   1. Implement the patient object
            /// TODO:   2. Read the contents of the patients.csv file into a collection of patients

            Console.WriteLine("TODO:   1. Implement the patient object");
            Console.WriteLine("TODO: 2. Read the contents of the patients.csv file into a collection of patients");

            var _patientRepository = new PatientsMethod();
            var vResult = _patientRepository.readFilePatient(InputFilePath,true);

            /// TODO:   3. Write the following output to the screen (First name, Last name, Age, Date of Birth, Account Number)
            /// TODO:       #3.1 - display all patients
            var vTodo = "TODO:#3.1 - display all patients";
            _patientRepository.get_print(vResult,vTodo);

            /// TODO:       #3.2 - display all patients with last name of 'smith'
            var vTodo3 = "TODO: #3.2 - display all patients with last name of 'smith'";
            var vResult2 = _patientRepository.getPatientByLastName(vResult , "Smith");
            _patientRepository.get_print(vResult2, vTodo3);

            /// TODO:       #3.3 - display all patients missing a date of birth
            var vTodo4 = "TODO: #3.3 - display all patients missing a date of birth";
            var vResult3 = _patientRepository.getPatientMissingDateBird(vResult, "");
            _patientRepository.get_print(vResult3, vTodo4);

            /// EXTRA TODO: #3.4 - display all patients with specific date of birth
            var vTodo5 = "EXTRA TODO: #3.4 - display all patients with specific date of birth";
            var vResult4 = _patientRepository.getPatientMissingDateBird(vResult, "08/01/2011");
            _patientRepository.get_print(vResult4, vTodo5);
        }
    }
}
