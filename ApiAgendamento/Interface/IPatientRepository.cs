
using ApiAgendamento.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Interface
{
    public interface IPatientRepository
    {
        public bool InsertPatient(Patient patient);
        public IEnumerable<Patient> SelectAllPatient();
        public Patient GetPatientByCpf(string cpf);
        public bool UpatePatient(Patient patient);
    }
}
