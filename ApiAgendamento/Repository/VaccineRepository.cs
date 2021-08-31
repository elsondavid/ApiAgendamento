using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiAgendamento.Repository
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly SqlConnection _connection;
        public VaccineRepository()
        {
            _connection = new SqlConnection("server=DAVID\\SQLEXPRESS;database=teste;user=sa;password=123456789");
            _connection.Open();
        }

        public Vaccine InsertVaccine(Vaccine vaccine)
        {
        
            var query = "INSERT INTO Vaccine (IdVaccineType, Manufacturer, ManufacturingDate, ExpirationDate, Description) OUTPUT INSERTED.Id VALUES(@IdVaccineType, @Manufacturer, @ManufacturingDate, @ExpirationDate, @Description)";

            var sqlParameter = new
            {
                IdVaccineType = vaccine.IdVaccineType,
                Manufacturer = vaccine.Manufacturer,
                ManufacturingDate = vaccine.ManufacturingDate,
                ExpirationDate = vaccine.ExpirationDate,
                Description = vaccine.Description

            };
             vaccine.Id = _connection.QuerySingle<int>(query, sqlParameter);
            //Vaccine resultVaccine = new();
            //resultVaccine.Id = id;
            //resultVaccine.IdVaccineType = vaccine.IdVaccineType;
            //resultVaccine.Manufacturer = vaccine.Manufacturer;
            //resultVaccine.ManufacturingDate = vaccine.ManufacturingDate;
            //resultVaccine.ExpirationDate = vaccine.ExpirationDate;
            //resultVaccine.Description = vaccine.Description;
            return vaccine;
        }

        public IEnumerable<Vaccine> SelectAllVaccine()
        {
            var query = "SELECT * FROM Vaccine";
            var result = new List<Vaccine>();
            result = (List<Vaccine>)_connection.Query<Vaccine>(query);
            return result;
        }
    }
}
