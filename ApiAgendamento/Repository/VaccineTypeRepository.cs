using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Repository
{
    public class VaccineTypeRepository : IVaccineTypeRepository
    {
        private readonly SqlConnection _connection;
        public VaccineTypeRepository()
        {
            _connection = new SqlConnection("server=DAVID\\SQLEXPRESS;database=teste;user=sa;password=123456789");
            _connection.Open();
        }

        public VaccineType InsertVaccineType(VaccineType vaccineType)
        {
            var query = "INSERT INTO VaccineType (Name) OUTPUT INSERTED.Id VALUES(@Name)";

            var sqlParameter = new
            {
                Name = vaccineType.Name
            };
             vaccineType.Id = _connection.QuerySingle<int>(query, sqlParameter);
            //VaccineType resultVaccineType = new();
            //resultVaccineType.Id = id;
            //resultVaccineType.Name = vaccineType.Name;
            return vaccineType;
        }

        public IEnumerable<VaccineType> SelectAllVaccineType()
        {
            var query = "SELECT * FROM VaccineType";
            var result = new List<VaccineType>();
            result = (List<VaccineType>)_connection.Query<VaccineType>(query);
            return result;
        }


    }
}
