using CH.DevTest.Junior.DataObjects;
using System.Collections.Generic;

namespace CH.DevTest.Junior.Data
{
    public interface IPatientsMethod
    {
        IEnumerable<Patient> getPatientByLastName(IEnumerable<Patient> pListPatient, string pLastName);
        IEnumerable<Patient> getPatientMissingDateBird(IEnumerable<Patient> pListPatient, string pDateTime);
        void get_print(IEnumerable<Patient> pListPatient, string pToDo);
        IEnumerable<Patient> readFilePatient(string pInputFilePath, bool pHaveHeader);
    }
}