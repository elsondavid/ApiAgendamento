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
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly SqlConnection _connection;
        public SchedulingRepository()
        {
            _connection = new SqlConnection("server=DAVID\\SQLEXPRESS;database=teste;user=sa;password=123456789");
            _connection.Open();
        }

        public Scheduling InsertScheduling(Scheduling scheduling)
        {
            var query = "INSERT INTO AGENDAMENTO (IdPaciente, IdVacina, Data) VALUES(@IdPaciente, @IdVacina, @Data)";

            var sqlParameter = new
            {
                IdPaciente = scheduling.IdPaciente,
                IdVacina = scheduling.IdVacina,
                Data = scheduling.Data
            };

            var resultScheduling = _connection.QuerySingle<Scheduling>(query, sqlParameter);
            return resultScheduling;
        }

        public Scheduling UpateScheduling(Scheduling scheduling)
        {
            var query = "UPDATE AGENDAMENTO SET  Data = @Data WHERE IdPaciente = @IdPaciente AND IdVacina = @IdVacina)";

            var sqlParameter = new
            {
                IdPaciente = scheduling.IdPaciente,
                IdVacina = scheduling.IdVacina,
                Data = scheduling.Data
            };

            var resultScheduling = _connection.QuerySingle<Scheduling>(query, sqlParameter);
            return resultScheduling;
        }
    }
}
