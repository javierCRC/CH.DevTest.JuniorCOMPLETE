using CH.DevTest.Junior.DataObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.DevTest.Junior.Data
{
    public class PatientsMethod : IPatientsMethod
    {
        public void get_print(IEnumerable<Patient> pListPatient, string pToDo)
        {

            Console.WriteLine(pToDo);
            foreach (var patient in pListPatient)
            {
                Console.WriteLine("FirstName: " + patient.FirstName +
                                  " -> LastName: " + patient.LastName +
                                  " -> Age: " + patient.Age +
                                  " -> DateOfBirth: " + patient.DateOfBirth +
                                  " -> AccountNumber: " + patient.AccountNumber);

            }
        }

        public IEnumerable<Patient> readFilePatient(string pInputFilePath, bool pHaveHeader)
        {

            string[] vResults = File.ReadAllLines(pInputFilePath);

            Console.WriteLine(vResults[0]);// TODO 3

            var myArray = vResults.Where((source, index) => index != 0).ToArray(); // removing header

            var patientArray = pHaveHeader ? myArray : vResults;

            var vListPatient = new List<Patient>();

            foreach (var patientLine in patientArray)
            {
                if (!string.IsNullOrWhiteSpace(patientLine))
                {
                    var vLine = patientLine.Split(',');

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

            return vListPatient;
        } // end of method for readFile and obtain a collectioc of patients

        public IEnumerable<Patient> getPatientByLastName(IEnumerable<Patient> pListPatient, string pLastName)
        {
            return pListPatient.Where(p => p.LastName == pLastName).ToList();
        }

        public IEnumerable<Patient> getPatientMissingDateBird(IEnumerable<Patient> pListPatient, string pDateTime)
        {

            if (!string.IsNullOrWhiteSpace(pDateTime))
            {

                return (from patient in pListPatient
                        where patient.DateOfBirth == Convert.ToDateTime(pDateTime)
                        select patient
                       ).ToList();
            }
            else
            {
                return pListPatient.Where(p => p.DateOfBirth.ToString() == pDateTime).ToList();
            }

        }
    }
}
