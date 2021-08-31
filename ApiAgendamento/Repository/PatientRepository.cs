using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiAgendamento.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly SqlConnection _connection;
        public PatientRepository()
        {
            _connection = new SqlConnection("server=DAVID\\SQLEXPRESS;database=teste;user=sa;password=123456789");
            _connection.Open();
        }

        public bool InsertPatient(Patient patient)
        {
            var dbPatient = GetPatientByCpf(patient.Cpf);

            if (dbPatient != null)
            {
                return false;
            }

            var query = "INSERT INTO Patient (Name, Cpf, Email, Password) OUTPUT INSERTED.Id VALUES(@Name, @Cpf, @Email, @Password)";

            var sqlParameter = new
            {
                Name     = patient.Name,
                Cpf      = patient.Cpf,
                Email    = patient.Email,
                Password = patient.Password
            };

            patient.Id = _connection.QuerySingle<int>(query, sqlParameter);
            return true;
        }

        public IEnumerable<Patient> SelectAllPatient()
        {
            var query = "SELECT * FROM Patient";
            return _connection.Query<Patient>(query);
        }

        public Patient GetPatientByCpf(string cpf)
        {
            var query = "SELECT * FROM Patient WHERE Cpf = @Cpf";
            
            var sqlParameter = new
            {
                Cpf = cpf
            };

            var resultPatient = _connection.QuerySingleOrDefault<Patient>(query, sqlParameter);

            return resultPatient;
        }

        public bool UpatePatient(Patient patient)
        {
            var query = "UPDATE PATIENT SET  Name = @Name, Cpf = @Cpf, Email = @Email, Password = @Password  WHERE Id = @Id";

            var sqlParameter = new
            {
                Id = patient.Id,
                Name = patient.Name,
                Cpf = patient.Cpf,
                Email = patient.Email,
                Password = patient.Password
            };

            patient.Id = _connection.QuerySingle<int>(query, sqlParameter);
            return true;
        }
    }
}
